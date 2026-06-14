using Microsoft.AspNetCore.Mvc;

namespace OrganicDesignPatterns.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class PatternDemosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}