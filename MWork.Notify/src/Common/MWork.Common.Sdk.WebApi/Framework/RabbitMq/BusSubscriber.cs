using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MWork.Common.Sdk.Abstractions.Queue;
using MWork.Common.Sdk.Extensions;
using RawRabbit;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
{
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IBusClient _busClient;
        private readonly IServiceProvider _serviceProvider;

        public BusSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices;
            _busClient = _serviceProvider.GetService<IBusClient>();
        }

        public IBusSubscriber SubscribeCommand<TCommand>(string queueName = null) where TCommand : IQueueCommand
        {
            _busClient.SubscribeAsync<TCommand, CorrelationContext>((command, ctx) =>
            {
                var commandHandler = _serviceProvider.GetService<IQueueCommandHandler<TCommand>>();
                return commandHandler.HandleAsync(command, ctx);
            }, ctx 
                => ctx.UseSubscribeConfiguration(cfg 
                    => cfg.FromDeclaredQueue(q 
                        => q.WithName(GetQueueName<TCommand>(queueName)))));

            return this;
        }

        public IBusSubscriber SubscribeEvent<TEvent>(string queueName = null) where TEvent : IQueueEvent
        {
            _busClient.SubscribeAsync<TEvent, CorrelationContext>((@event, ctx) =>
            {
                var eventHandler = _serviceProvider.GetService<IQueueEventHandler<TEvent>>();
                return eventHandler.HandleAsync(@event, ctx);
            }, ctx 
                => ctx.UseSubscribeConfiguration(cfg 
                    => cfg.FromDeclaredQueue(q 
                        => q.WithName(GetQueueName<TEvent>(queueName)))));

            return this;
        }

        private static string GetQueueName<T>(string name = null)
            => (string.IsNullOrWhiteSpace(name)
                    ? $"{Assembly.GetEntryAssembly()?.GetName().Name}/{typeof(T).Name.Underscore()}"
                    : $"{name}/{typeof(T).Name.Underscore()}"
                )
                .ToLowerInvariant();
    }
}