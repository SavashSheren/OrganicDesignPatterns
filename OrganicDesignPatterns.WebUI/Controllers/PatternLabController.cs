using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Controllers;

public class PatternLabController : Controller
{
    public IActionResult Index()
    {
        var demos = new List<PatternDemoCardViewModel>
        {
            new()
            {
                PatternName = "Strategy Pattern",
                ScenarioName = "Discount Calculation",
                Description = "Calculates discount amounts using percentage, fixed amount and no-discount strategies.",
                Endpoint = "POST /api/Discounts/calculate",
                RequestSample = """
                {
                  "discountType": 1,
                  "orderTotal": 1000,
                  "discountValue": 15
                }
                """,
                ResponseSample = """
                {
                  "discountAmount": 150,
                  "finalTotal": 850
                }
                """
            },
            new()
            {
                PatternName = "Decorator Pattern",
                ScenarioName = "Shipping Extras",
                Description = "Adds fast delivery, gift package and cold chain package dynamically on top of base shipping.",
                Endpoint = "POST /api/Shipping/calculate",
                RequestSample = """
                {
                  "baseShippingPrice": 50,
                  "fastDelivery": true,
                  "giftPackage": true,
                  "coldChainPackage": true
                }
                """,
                ResponseSample = """
                {
                  "totalShippingPrice": 140,
                  "appliedServices": [
                    "Standard Shipping",
                    "Fast Delivery",
                    "Gift Package",
                    "Cold Chain Package"
                  ]
                }
                """
            },
            new()
            {
                PatternName = "Factory Method",
                ScenarioName = "Mail Template Generation",
                Description = "Generates the correct mail template according to the order status.",
                Endpoint = "POST /api/MailTemplates/generate",
                RequestSample = """
                {
                  "orderStatus": 2,
                  "customerName": "Savas Seren",
                  "orderNumber": "ORD-2026-1001",
                  "totalAmount": 850
                }
                """,
                ResponseSample = """
                {
                  "templateName": "Approved Order Template",
                  "subject": "Order Approved - ORD-2026-1001"
                }
                """
            },
            new()
            {
                PatternName = "Observer Pattern",
                ScenarioName = "Order Approval Event",
                Description = "Triggers multiple observers after order approval: email notification, stock movement and log creation.",
                Endpoint = "POST /api/OrderEvents/approve",
                RequestSample = """
                {
                  "orderNumber": "ORD-2026-1003",
                  "customerName": "Savas Seren",
                  "customerEmail": "savas@example.com",
                  "productId": 1,
                  "quantity": 2,
                  "totalAmount": 850
                }
                """,
                ResponseSample = """
                {
                  "isSuccessful": true,
                  "observerResults": [
                    "EmailNotificationObserver",
                    "StockMovementObserver",
                    "NotificationLogObserver"
                  ]
                }
                """
            },
            new()
            {
                PatternName = "Chain of Responsibility",
                ScenarioName = "Order Validation Flow",
                Description = "Validates customer, basket, stock, payment and shipping address step by step.",
                Endpoint = "POST /api/OrderValidation/validate",
                RequestSample = """
                {
                  "customerName": "Savas Seren",
                  "customerEmail": "savas@example.com",
                  "shippingAddress": "Istanbul Pendik Kurtkoy",
                  "paymentMethod": 1,
                  "items": [
                    {
                      "productId": 1,
                      "productName": "Organic Apple",
                      "requestedQuantity": 2,
                      "availableStock": 50
                    }
                  ]
                }
                """,
                ResponseSample = """
                {
                  "isValid": true,
                  "steps": [
                    "CustomerInfoValidationHandler",
                    "BasketValidationHandler",
                    "StockValidationHandler",
                    "PaymentValidationHandler",
                    "ShippingAddressValidationHandler"
                  ]
                }
                """
            },
            new()
            {
                PatternName = "Architecture Patterns",
                ScenarioName = "Repository + Unit of Work + CQRS",
                Description = "Shows the main request flow from controller to database through clean architecture layers.",
                Endpoint = "Controller → MediatR → Handler → UnitOfWork → Repository → EF Core",
                RequestSample = """
                GET /api/Products
                GET /api/Categories
                """,
                ResponseSample = """
                Clean Architecture layers:
                Domain
                Application
                Persistence
                Infrastructure
                WebAPI
                WebUI
                """,
                BadgeText = "Core"
            }
        };

        return View(demos);
    }
}