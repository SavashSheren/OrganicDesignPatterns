using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OrganicDesignPatterns.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}