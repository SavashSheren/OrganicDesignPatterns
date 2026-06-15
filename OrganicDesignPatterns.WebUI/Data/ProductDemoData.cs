using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Data;

public static class ProductDemoData
{
    public static List<ProductCardViewModel> GetProducts()
    {
        return new List<ProductCardViewModel>
        {
            new()
            {
                ProductId = 1,
                Name = "Organic Tomato",
                CategoryName = "Vegetables",
                Description = "Used in product listing and validation scenarios.",
                Price = 80,
                DiscountedPrice = null,
                Stock = 75,
                IsFeatured = true,
                ImageUrl = "/organic-html/assets/images/product/product2.png"
            },
            new()
            {
                ProductId = 2,
                Name = "Fresh Green Pepper",
                CategoryName = "Vegetables",
                Description = "Used in chain of responsibility stock validation flow.",
                Price = 65,
                DiscountedPrice = 55,
                Stock = 100,
                IsFeatured = false,
                ImageUrl = "/organic-html/assets/images/product/product11.png"
            },
            new()
            {
                ProductId = 3,
                Name = "Strawberry Jam",
                CategoryName = "Discount Products",
                Description = "Used in strategy pattern fixed amount discount scenario.",
                Price = 250,
                DiscountedPrice = 220,
                Stock = 20,
                IsFeatured = true,
                ImageUrl = "/organic-html/assets/images/product/product12.png"
            },
            new()
            {
                ProductId = 4,
                Name = "Organic Vegetable Basket",
                CategoryName = "Order Event Products",
                Description = "Used in observer pattern order approval event.",
                Price = 450,
                DiscountedPrice = 399,
                Stock = 15,
                IsFeatured = true,
                ImageUrl = "/organic-html/assets/images/product/product16.png"
            },
            new()
            {
                ProductId = 5,
                Name = "Fresh Cherry",
                CategoryName = "Fresh Fruits",
                Description = "Used in discount and stock movement scenarios.",
                Price = 120,
                DiscountedPrice = 99,
                Stock = 50,
                IsFeatured = true,
                ImageUrl = "/organic-html/assets/images/product/product20.png"
            },
            new()
            {
                ProductId = 6,
                Name = "Organic Orange",
                CategoryName = "Fresh Fruits",
                Description = "Used in product showcase and CQRS query scenarios.",
                Price = 90,
                DiscountedPrice = null,
                Stock = 60,
                IsFeatured = false,
                ImageUrl = "/organic-html/assets/images/product/product24.png"
            }
        };
    }

    public static ProductCardViewModel? GetProductById(int id)
    {
        return GetProducts().FirstOrDefault(x => x.ProductId == id);
    }
}