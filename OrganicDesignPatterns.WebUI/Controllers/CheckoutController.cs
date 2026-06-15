using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Extensions;
using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Controllers;
public class CheckoutController : Controller
{
    private const string BasketSessionKey = "OrganicBasket";
    private const string DemoOrdersSessionKey = "DemoOrders";

    public IActionResult Index()
    {
        var basketItems = GetBasketItems();

        if (!basketItems.Any())
        {
            return RedirectToAction("Index", "Basket");
        }

        var subtotal = basketItems.Sum(x => x.TotalPrice);
        var shippingCost = subtotal >= 300 ? 0 : 25;

        var model = new CheckoutViewModel
        {
            BasketItems = basketItems,
            Subtotal = subtotal,
            ShippingCost = shippingCost,
            TotalPrice = subtotal + shippingCost
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Complete(CheckoutViewModel model)
    {
        var basketItems = GetBasketItems();

        if (!basketItems.Any())
        {
            return RedirectToAction("Index", "Basket");
        }

        var subtotal = basketItems.Sum(x => x.TotalPrice);
        var shippingCost = subtotal >= 300 ? 0 : 25;
        var totalPrice = subtotal + shippingCost;
        var orderNumber = $"ORD-{DateTime.Now:yyyyMMddHHmmss}";

        var demoOrder = new DemoOrderViewModel
        {
            OrderNumber = orderNumber,
            CustomerName = model.FullName,
            Email = model.Email,
            Phone = model.Phone,
            ShippingAddress = model.ShippingAddress,
            PaymentMethod = model.PaymentMethod,
            OrderDate = DateTime.Now,
            TotalPrice = totalPrice,
            Status = "Pending",
            Items = basketItems
        };

        var demoOrders = HttpContext.Session.GetObjectFromJson<List<DemoOrderViewModel>>(DemoOrdersSessionKey)
                         ?? new List<DemoOrderViewModel>();

        demoOrders.Insert(0, demoOrder);

        HttpContext.Session.SetObjectAsJson(DemoOrdersSessionKey, demoOrders);

        TempData["OrderNumber"] = orderNumber;
        TempData["CustomerName"] = model.FullName;
        TempData["TotalPrice"] = totalPrice.ToString("0.00");

        HttpContext.Session.Remove(BasketSessionKey);

        return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
        return View();
    }

    private List<BasketItemViewModel> GetBasketItems()
    {
        return HttpContext.Session.GetObjectFromJson<List<BasketItemViewModel>>(BasketSessionKey)
               ?? new List<BasketItemViewModel>();
    }
}