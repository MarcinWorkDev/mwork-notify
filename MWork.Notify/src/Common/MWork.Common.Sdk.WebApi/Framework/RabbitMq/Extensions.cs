using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MWork.Common.Sdk.Abstractions.Queue;
using MWork.Common.Sdk.Extensions;
using RawRabbit.Common;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Instantiation;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
{
    public static class Extensions
    {
        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
            => new BusSubscriber(app);

        public static void AddRabbitMq(this IServiceCollection services, Action<RabbitMqOptions> optionsBuilder = null)
        {
            services.Configure<RabbitMqOptions>(o => optionsBuilder?.Invoke(o));
            
            var assembly = Assembly.GetCallingAssembly();

            var registerTypes = new List<Type>()
            {
                typeof(IQueueEventHandler<>),
                typeof(IQueueCommandHandler<>)
            };

            var types = assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces().Any(t => registerTypes.Contains(t)));

            foreach (var type in types)
            {
                services.AddScoped(type);
            }

            services.AddSingleton<IBusPublisher, BusPublisher>();

            services.AddSingleton(x =>
            {
                return RawRabbitFactory.CreateInstanceFactory(new RawRabbitOptions
                {
                    ClientConfiguration = new RawRabbitConfiguration()
                    {
                        VirtualHost = "/",
                        Hostnames = {"docker-farm"},
                        Port = 5672,
                        Username = "guest",
                        Password = "guest"
                    },
                    DependencyInjection = ioc =>
                    {
                        ioc.AddSingleton<INamingConventions, CustomNamingConventions>();
                    },
                    Plugins = p => p
                        .UseMessageContext<CorrelationContext>()
                        .UseContextForwarding()
                }).Create();
            });
        }
        
        private class CustomNamingConventions : NamingConventions
        {
            public CustomNamingConventions()
            {
                ExchangeNamingConvention = type => type?.Name?.Underscore().ToLowerInvariant() ?? string.Empty;
            }
        }      
    }
}