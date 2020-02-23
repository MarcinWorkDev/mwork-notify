using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.DependencyInjection.ServiceCollection;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Instantiation;

namespace MWork.Common.Sdk.RabbitMQ
{
    public static class Extensions
    {
        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
            => new BusSubscriber(app);

        public static IServiceCollection AddRabbitMq(this IServiceCollection services, Action<RabbitMqOptions> optionsBuilder = null)
        {
            var options = new RabbitMqOptions();
            optionsBuilder?.Invoke(options);
            
            services.AddRawRabbit(new RawRabbitOptions()
            {
                ClientConfiguration = new RawRabbitConfiguration()
                {
                    VirtualHost = options.VirtualHost,
                    Hostnames = options.Hostnames,
                    Port = options.Port,
                    Username = options.Username,
                    Password = options.Password
                },
                Plugins = plg => plg
                    .UseMessageContext(ctx => new CorrelationContext())
            });
            
            var assembly = Assembly.GetCallingAssembly();

            var registerTypes = new List<string>()
            {
                typeof(IEventHandler<>).Name,
                typeof(ICommandHandler<>).Name
            };

            var types = assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces().Any(t => registerTypes.Contains(t.Name))); // TODO: Can be better / maybe MediatR?

            var busClient = services.BuildServiceProvider().GetService<IBusClient>();
            foreach (var type in types)
            {
                services.AddScoped(type);
            }
            
            services.AddSingleton<IBusPublisher, BusPublisher>();
            return services;
        }
    }
}