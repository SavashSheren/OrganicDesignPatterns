using OrganicDesignPatterns.WebUI.Models;

namespace OrganicDesignPatterns.WebUI.Data;

public static class CategoryDemoData
{
    public static List<CategoryCardViewModel> GetCategories()
    {
        return new List<CategoryCardViewModel>
        {
            new()
            {
                CategoryId = 1,
                Name = "Fresh Fruits",
                Description = "Organic and seasonal fruits selected for healthy living.",
                BadgeText = "Popular",
                PatternName = "Strategy Pattern",
                ScenarioDescription = "Used in discount calculation and product pricing scenarios.",
                ImageUrl = "/organic-html/assets/images/product/product24.png"
            },
            new()
            {
                CategoryId = 2,
                Name = "Vegetables",
                Description = "Fresh vegetables supplied from local organic farms.",
                BadgeText = "Natural",
                PatternName = "Repository Pattern",
                ScenarioDescription = "Used in product listing and category-based query scenarios.",
                ImageUrl = "/organic-html/assets/images/product/product11.png"
            },
            new()
            {
                CategoryId = 3,
                Name = "Cold Chain Products",
                Description = "Special delivery products that require cold chain shipping.",
                BadgeText = "Decorator",
                PatternName = "Decorator Pattern",
                ScenarioDescription = "Used in shipping calculation with cold chain package extras.",
                ImageUrl = "/organic-html/assets/images/product/product1.png"
            },
            new()
            {
                CategoryId = 4,
                Name = "Discount Products",
                Description = "Products used in strategy pattern discount scenarios.",
                BadgeText = "Strategy",
                PatternName = "Strategy Pattern",
                ScenarioDescription = "Used for percentage and fixed amount discount calculations.",
                ImageUrl = "/organic-html/assets/images/product/product12.png"
            },
            new()
            {
                CategoryId = 5,
                Name = "Order Event Products",
                Description = "Products used in observer pattern stock movement scenarios.",
                BadgeText = "Observer",
                PatternName = "Observer Pattern",
                ScenarioDescription = "Used when an approved order triggers stock movement and notifications.",
                ImageUrl = "/organic-html/assets/images/product/product25.png"
            },
            new()
            {
                CategoryId = 6,
                Name = "Validation Products",
                Description = "Products used in order validation chain scenarios.",
                BadgeText = "Chain",
                PatternName = "Chain of Responsibility",
                ScenarioDescription = "Used in customer, basket, stock, payment and address validation flow.",
                ImageUrl = "/organic-html/assets/images/product/product26.png"
            }
        };
    }

    public static CategoryCardViewModel? GetCategoryById(int id)
    {
        return GetCategories().FirstOrDefault(x => x.CategoryId == id);
    }
}