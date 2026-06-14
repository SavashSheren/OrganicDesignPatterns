using Microsoft.AspNetCore.Mvc;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class PatternLabController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}