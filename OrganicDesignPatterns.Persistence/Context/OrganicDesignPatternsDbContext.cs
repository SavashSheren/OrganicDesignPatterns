using Microsoft.EntityFrameworkCore;
using OrganicDesignPatterns.Domain.Entities;

namespace OrganicDesignPatterns.Persistence.Context;

public class OrganicDesignPatternsDbContext : DbContext
{
    public OrganicDesignPatternsDbContext(DbContextOptions<OrganicDesignPatternsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Basket> Baskets { get; set; }

    public DbSet<BasketItem> BasketItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Discount> Discounts { get; set; }

    public DbSet<NotificationLog> NotificationLogs { get; set; }

    public DbSet<StockMovement> StockMovements { get; set; }

    public DbSet<ShippingOption> ShippingOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Customer>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Basket>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<BasketItem>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<OrderDetail>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Discount>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<NotificationLog>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<StockMovement>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<ShippingOption>().HasQueryFilter(x => !x.IsDeleted);

        modelBuilder.Entity<Product>()
            .Property(x => x.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .Property(x => x.DiscountedPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<BasketItem>()
            .Property(x => x.UnitPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .Property(x => x.SubTotal)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .Property(x => x.DiscountAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .Property(x => x.ShippingPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .Property(x => x.TotalAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<OrderDetail>()
            .Property(x => x.UnitPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Discount>()
            .Property(x => x.Rate)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Discount>()
            .Property(x => x.MinimumOrderAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ShippingOption>()
            .Property(x => x.BasePrice)
            .HasColumnType("decimal(18,2)");
    }
}