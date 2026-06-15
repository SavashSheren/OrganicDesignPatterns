using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Data;
using OrganicDesignPatterns.WebUI.Extensions;
using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class BasketController : Controller
{
    private const string BasketSessionKey = "OrganicBasket";

    public IActionResult Index()
    {
        var basketItems = GetBasketItems();

        ViewBag.TotalPrice = basketItems.Sum(x => x.TotalPrice);
        ViewBag.TotalQuantity = basketItems.Sum(x => x.Quantity);

        return View(basketItems);
    }

    public IActionResult Add(int id)
    {
        var product = ProductDemoData.GetProductById(id);

        if (product == null)
        {
            return RedirectToAction("Index", "Products");
        }

        var basketItems = GetBasketItems();

        var existingItem = basketItems.FirstOrDefault(x => x.ProductId == id);

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            basketItems.Add(new BasketItemViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                CategoryName = product.CategoryName,
                ImageUrl = product.ImageUrl,
                UnitPrice = product.DiscountedPrice ?? product.Price,
                Quantity = 1
            });
        }

        SaveBasketItems(basketItems);

        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        var basketItems = GetBasketItems();

        var item = basketItems.FirstOrDefault(x => x.ProductId == id);

        if (item != null)
        {
            basketItems.Remove(item);
            SaveBasketItems(basketItems);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Increase(int id)
    {
        var basketItems = GetBasketItems();

        var item = basketItems.FirstOrDefault(x => x.ProductId == id);

        if (item != null)
        {
            item.Quantity++;
            SaveBasketItems(basketItems);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Decrease(int id)
    {
        var basketItems = GetBasketItems();

        var item = basketItems.FirstOrDefault(x => x.ProductId == id);

        if (item != null)
        {
            item.Quantity--;

            if (item.Quantity <= 0)
            {
                basketItems.Remove(item);
            }

            SaveBasketItems(basketItems);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        HttpContext.Session.Remove(BasketSessionKey);
        return RedirectToAction("Index");
    }

    private List<BasketItemViewModel> GetBasketItems()
    {
        return HttpContext.Session.GetObjectFromJson<List<BasketItemViewModel>>(BasketSessionKey)
               ?? new List<BasketItemViewModel>();
    }

    private void SaveBasketItems(List<BasketItemViewModel> basketItems)
    {
        HttpContext.Session.SetObjectAsJson(BasketSessionKey, basketItems);
    }
}