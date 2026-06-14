using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class CategoriesController : Controller
{
    public IActionResult Index()
    {
        var categories = new List<CategoryCardViewModel>
        {
            new()
            {
                Name = "Fresh Fruits",
                Description = "Organic and seasonal fruits selected for healthy living.",
                BadgeText = "Popular"
            },
            new()
            {
                Name = "Vegetables",
                Description = "Fresh vegetables supplied from local organic farms.",
                BadgeText = "Natural"
            },
            new()
            {
                Name = "Cold Chain Products",
                Description = "Special delivery products that require cold chain shipping.",
                BadgeText = "Decorator"
            },
            new()
            {
                Name = "Discount Products",
                Description = "Products used in strategy pattern discount scenarios.",
                BadgeText = "Strategy"
            },
            new()
            {
                Name = "Order Event Products",
                Description = "Products used in observer pattern stock movement scenarios.",
                BadgeText = "Observer"
            },
            new()
            {
                Name = "Validation Products",
                Description = "Products used in order validation chain scenarios.",
                BadgeText = "Chain"
            }
        };

        return View(categories);
    }
}