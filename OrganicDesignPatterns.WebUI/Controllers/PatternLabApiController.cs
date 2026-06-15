using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class PatternLabApiController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PatternLabApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost]
    public async Task<IActionResult> RunDiscount()
    {
        var requestBody = new
        {
            discountType = 1,
            orderTotal = 1000,
            discountValue = 15
        };

        var result = await SendPostRequestAsync("/api/Discounts/calculate", requestBody);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> RunShipping()
    {
        var requestBody = new
        {
            baseShippingPrice = 50,
            fastDelivery = true,
            giftPackage = true,
            coldChainPackage = true
        };

        var result = await SendPostRequestAsync("/api/Shipping/calculate", requestBody);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> RunMailTemplate()
    {
        var requestBody = new
        {
            orderStatus = 4,
            customerFullName = "John Carter",
            orderNumber = "ORD-2026-1001",
            totalAmount = 1250
        };

        var result = await SendPostRequestAsync("/api/MailTemplates/generate", requestBody);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> RunOrderValidation()
    {
        var requestBody = new
        {
            customerFullName = "John Carter",
            customerEmail = "customer@example.com",
            shippingAddress = "London Street No: 10",
            paymentMethod = 1,
            items = new[]
            {
                new
                {
                    productId = 1,
                    productName = "Organic Apple",
                    quantity = 2,
                    stock = 30,
                    unitPrice = 12.50
                }
            }
        };

        var result = await SendPostRequestAsync("/api/OrderValidation/validate", requestBody);
        return Json(result);
    }

    private async Task<object> SendPostRequestAsync(string endpoint, object requestBody)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("OrganicApi");

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            return new
            {
                success = response.IsSuccessStatusCode,
                statusCode = (int)response.StatusCode,
                endpoint,
                request = requestBody,
                response = TryFormatJson(responseContent)
            };
        }
        catch (Exception ex)
        {
            return new
            {
                success = false,
                statusCode = 500,
                endpoint,
                error = ex.Message
            };
        }
    }

    private static object TryFormatJson(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<object>(json) ?? json;
        }
        catch
        {
            return json;
        }
    }
}