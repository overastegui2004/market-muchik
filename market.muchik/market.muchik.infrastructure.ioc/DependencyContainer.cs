using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using market.muchik.domain.bus;
using market.muchik.infrastructure.bus;
using market.muchik.infrastructure.bus.settings;
using System.Reflection;

namespace market.muchik.infrastructure.ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration) 
        {
            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Event Bus
            services.AddSingleton<IEventBus, RabbitMqBus>(config =>
            {
                var mediatorFactory = config.GetService<IMediator>();
                var scopeFactory = config.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = config.GetService<IOptions<RabbitMqSettings>>();
                return new RabbitMqBus(mediatorFactory, scopeFactory, optionsFactory);
            });

            return services;
        }
    }
}
