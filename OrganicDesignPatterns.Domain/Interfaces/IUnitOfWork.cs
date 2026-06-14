using OrganicDesignPatterns.Domain.Entities;

namespace OrganicDesignPatterns.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Product> Products { get; }

    IRepository<Category> Categories { get; }

    IRepository<Customer> Customers { get; }

    IRepository<Basket> Baskets { get; }

    IRepository<BasketItem> BasketItems { get; }

    IRepository<Order> Orders { get; }

    IRepository<OrderDetail> OrderDetails { get; }

    IRepository<Discount> Discounts { get; }

    IRepository<NotificationLog> NotificationLogs { get; }

    IRepository<StockMovement> StockMovements { get; }

    IRepository<ShippingOption> ShippingOptions { get; }

    Task<int> SaveChangesAsync();
}