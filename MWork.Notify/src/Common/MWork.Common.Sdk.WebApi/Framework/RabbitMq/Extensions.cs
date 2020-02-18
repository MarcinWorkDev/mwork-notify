using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MWork.Common.Sdk.Abstractions.Queue;
using MWork.Common.Sdk.WebApi.Framework.Mongo;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Configuration.Queue;
using RawRabbit.DependencyInjection.ServiceCollection;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Instantiation;
using RawRabbit.Logging;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
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
                    .UseAttributeRouting()
                    .UseMessageContext(ctx => new CorrelationContext())
            });
            
            var assembly = Assembly.GetCallingAssembly();

            /*var registerTypes = new List<Type>()
            {
                typeof(IQueueEventHandler<>),
                typeof(IQueueCommandHandler<>)
            };

            var types = assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces().Any(t => registerTypes.Contains(t)));

            var busClient = services.BuildServiceProvider().GetService<IBusClient>();
            foreach (var type in types)
            {
                services.AddScoped(type);
                busClient.DeclareQueueAsync();
                busClient.BindQueueAsync<TEvent>();
            }*/
            
            services.AddSingleton<IBusPublisher, BusPublisher>();
            return services;
        }
    }
}