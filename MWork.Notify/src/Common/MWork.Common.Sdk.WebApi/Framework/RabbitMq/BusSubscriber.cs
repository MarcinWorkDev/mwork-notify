using System;
using System.Reflection;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MWork.Common.Sdk.Abstractions.CQRS;
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

        public IBusSubscriber SubscribeCommand<TCommand>(string exchangeName = null, string queueName = null, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            _busClient.SubscribeAsync<TCommand, CorrelationContext>((command, ctx) =>
            {
                var commandHandler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
                return commandHandler.HandleAsync(command, ctx, cancellationToken);
            }, ct: cancellationToken);

            return this;
        }

        public IBusSubscriber SubscribeEvent<TEvent>(string exchangeName = null, string queueName = null, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            _busClient.SubscribeAsync<TEvent, CorrelationContext>((@event, ctx) =>
            {
                var eventHandler = _serviceProvider.GetService<IEventHandler<TEvent>>();
                return eventHandler.HandleAsync(@event, ctx, cancellationToken);
            }, ct: cancellationToken);

            return this;
        }
    }
}