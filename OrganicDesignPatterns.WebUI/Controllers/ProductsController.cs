using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Data;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var products = ProductDemoData.GetProducts();
        return View(products);
    }

    public IActionResult Detail(int id)
    {
        var product = ProductDemoData.GetProductById(id);

        if (product == null)
        {
            return RedirectToAction("Index");
        }

        return View(product);
    }
}