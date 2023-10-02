using System.Reflection;
using DevFreela.Application.Consumers;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => 
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddConsumers();
        
        return services;
    }
    
    private static IServiceCollection AddConsumers(this IServiceCollection services) {
        services.AddHostedService<PaymentApprovedConsumer>();
            
        return services;
    }
}