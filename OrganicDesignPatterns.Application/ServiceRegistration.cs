using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrganicDesignPatterns.Application.Behaviors;
using OrganicDesignPatterns.Application.DesignPatterns.Strategy;
using System.Reflection;
using OrganicDesignPatterns.Application.DesignPatterns.Factory;

namespace OrganicDesignPatterns.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IDiscountStrategy, NoDiscountStrategy>();
        services.AddScoped<IDiscountStrategy, PercentageDiscountStrategy>();
        services.AddScoped<IDiscountStrategy, FixedAmountDiscountStrategy>();
        services.AddScoped<DiscountStrategyContext>();

        services.AddScoped<MailTemplateCreator, PendingOrderMailTemplateCreator>();
        services.AddScoped<MailTemplateCreator, ApprovedOrderMailTemplateCreator>();
        services.AddScoped<MailTemplateCreator, PreparingOrderMailTemplateCreator>();
        services.AddScoped<MailTemplateCreator, ShippedOrderMailTemplateCreator>();
        services.AddScoped<MailTemplateCreator, DeliveredOrderMailTemplateCreator>();
        services.AddScoped<MailTemplateCreator, CancelledOrderMailTemplateCreator>();
        services.AddScoped<MailTemplateFactoryContext>();

        return services;
    }
}