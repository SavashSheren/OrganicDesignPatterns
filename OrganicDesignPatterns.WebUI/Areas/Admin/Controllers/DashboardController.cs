using Microsoft.AspNetCore.Mvc;

namespace OrganicDesignPatterns.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}