using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Data;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class CategoriesController : Controller
{
    public IActionResult Index()
    {
        var categories = CategoryDemoData.GetCategories();
        return View(categories);
    }

    public IActionResult Detail(int id)
    {
        var category = CategoryDemoData.GetCategoryById(id);

        if (category == null)
        {
            return RedirectToAction("Index");
        }

        return View(category);
    }
}