using OrganicDesignPatterns.Domain.Entities;
using OrganicDesignPatterns.Domain.Interfaces;
using OrganicDesignPatterns.Persistence.Context;
using OrganicDesignPatterns.Persistence.Repositories;

namespace OrganicDesignPatterns.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrganicDesignPatternsDbContext _context;

    private IRepository<Product>? _products;
    private IRepository<Category>? _categories;
    private IRepository<Customer>? _customers;
    private IRepository<Basket>? _baskets;
    private IRepository<BasketItem>? _basketItems;
    private IRepository<Order>? _orders;
    private IRepository<OrderDetail>? _orderDetails;
    private IRepository<Discount>? _discounts;
    private IRepository<NotificationLog>? _notificationLogs;
    private IRepository<StockMovement>? _stockMovements;
    private IRepository<ShippingOption>? _shippingOptions;

    public UnitOfWork(OrganicDesignPatternsDbContext context)
    {
        _context = context;
    }

    public IRepository<Product> Products =>
        _products ??= new GenericRepository<Product>(_context);

    public IRepository<Category> Categories =>
        _categories ??= new GenericRepository<Category>(_context);

    public IRepository<Customer> Customers =>
        _customers ??= new GenericRepository<Customer>(_context);

    public IRepository<Basket> Baskets =>
        _baskets ??= new GenericRepository<Basket>(_context);

    public IRepository<BasketItem> BasketItems =>
        _basketItems ??= new GenericRepository<BasketItem>(_context);

    public IRepository<Order> Orders =>
        _orders ??= new GenericRepository<Order>(_context);

    public IRepository<OrderDetail> OrderDetails =>
        _orderDetails ??= new GenericRepository<OrderDetail>(_context);

    public IRepository<Discount> Discounts =>
        _discounts ??= new GenericRepository<Discount>(_context);

    public IRepository<NotificationLog> NotificationLogs =>
        _notificationLogs ??= new GenericRepository<NotificationLog>(_context);

    public IRepository<StockMovement> StockMovements =>
        _stockMovements ??= new GenericRepository<StockMovement>(_context);

    public IRepository<ShippingOption> ShippingOptions =>
        _shippingOptions ??= new GenericRepository<ShippingOption>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}