using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var products = new List<ProductCardViewModel>
        {
            new()
            {
                Name = "Organic Apple",
                CategoryName = "Fresh Fruits",
                Description = "Used in discount and stock movement scenarios.",
                Price = 120,
                DiscountedPrice = 99,
                Stock = 50,
                IsFeatured = true
            },
            new()
            {
                Name = "Organic Tomato",
                CategoryName = "Vegetables",
                Description = "Used in product listing and validation scenarios.",
                Price = 80,
                DiscountedPrice = null,
                Stock = 75,
                IsFeatured = false
            },
            new()
            {
                Name = "Cold Chain Milk",
                CategoryName = "Cold Chain Products",
                Description = "Used in decorator pattern shipping calculation.",
                Price = 150,
                DiscountedPrice = 135,
                Stock = 30,
                IsFeatured = true
            },
            new()
            {
                Name = "Organic Honey",
                CategoryName = "Discount Products",
                Description = "Used in strategy pattern fixed amount discount scenario.",
                Price = 250,
                DiscountedPrice = 220,
                Stock = 20,
                IsFeatured = true
            },
            new()
            {
                Name = "Fresh Lettuce",
                CategoryName = "Validation Products",
                Description = "Used in chain of responsibility stock validation flow.",
                Price = 60,
                DiscountedPrice = null,
                Stock = 100,
                IsFeatured = false
            },
            new()
            {
                Name = "Organic Basket Pack",
                CategoryName = "Order Event Products",
                Description = "Used in observer pattern order approval event.",
                Price = 450,
                DiscountedPrice = 399,
                Stock = 15,
                IsFeatured = true
            }
        };

        return View(products);
    }
}