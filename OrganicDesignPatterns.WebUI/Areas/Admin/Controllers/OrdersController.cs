using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Extensions;
using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class OrdersController : Controller
{
    private const string DemoOrdersSessionKey = "DemoOrders";

    public IActionResult Index()
    {
        var orders = HttpContext.Session.GetObjectFromJson<List<DemoOrderViewModel>>(DemoOrdersSessionKey)
                     ?? new List<DemoOrderViewModel>();

        return View(orders);
    }

    public IActionResult Approve(string orderNumber)
    {
        var orders = HttpContext.Session.GetObjectFromJson<List<DemoOrderViewModel>>(DemoOrdersSessionKey)
                     ?? new List<DemoOrderViewModel>();

        var order = orders.FirstOrDefault(x => x.OrderNumber == orderNumber);

        if (order != null)
        {
            order.Status = "Approved";
            HttpContext.Session.SetObjectAsJson(DemoOrdersSessionKey, orders);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Cancel(string orderNumber)
    {
        var orders = HttpContext.Session.GetObjectFromJson<List<DemoOrderViewModel>>(DemoOrdersSessionKey)
                     ?? new List<DemoOrderViewModel>();

        var order = orders.FirstOrDefault(x => x.OrderNumber == orderNumber);

        if (order != null)
        {
            order.Status = "Cancelled";
            HttpContext.Session.SetObjectAsJson(DemoOrdersSessionKey, orders);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Detail(string orderNumber)
    {
        var orders = HttpContext.Session.GetObjectFromJson<List<DemoOrderViewModel>>(DemoOrdersSessionKey)
                     ?? new List<DemoOrderViewModel>();

        var order = orders.FirstOrDefault(x => x.OrderNumber == orderNumber);

        if (order == null)
        {
            return RedirectToAction("Index");
        }

        return View(order);
    }
}