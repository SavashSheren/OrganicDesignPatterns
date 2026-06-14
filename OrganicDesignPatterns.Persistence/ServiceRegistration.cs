using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganicDesignPatterns.Domain.Interfaces;
using OrganicDesignPatterns.Persistence.Context;
using OrganicDesignPatterns.Persistence.Repositories;
using OrganicDesignPatterns.Persistence.UnitOfWork;

namespace OrganicDesignPatterns.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<OrganicDesignPatternsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        return services;
    }
}