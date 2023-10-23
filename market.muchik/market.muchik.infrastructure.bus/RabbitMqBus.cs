﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using market.muchik.domain.bus;
using market.muchik.domain.commands;
using market.muchik.domain.events;
using market.muchik.infrastructure.bus.settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace market.muchik.infrastructure.bus
{
    public sealed class RabbitMqBus : IEventBus
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IMediator _mediator;
        private readonly RabbitMqSettings _settings;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;

        public RabbitMqBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory, IOptions<RabbitMqSettings> settings) 
        {
            _serviceScopeFactory = serviceScopeFactory;
            _mediator = mediator;
            _settings = settings.Value;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public void Publish<T>(T @event) where T : Event
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = _settings.HostName,
                UserName = _settings.Username,
                Password = _settings.Password,

   
            };

            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            var eventName = @event.GetType().Name;

            channel.QueueDeclare(
                queue: eventName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            string message = JsonConvert.SerializeObject(@event);

            byte[] body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", eventName, null, body);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            /* class Order -> eventName = "Order" handlerType = Order */

            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if(!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if(!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(b => b.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler exeption {handlerType.Name} ya fue registrado anteriormente por {eventName}", nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

           InitBasicConsume<T>();

        }

        private void InitBasicConsume<T>() where T : Event
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = _settings.HostName,
                UserName = _settings.Username,
                Password = _settings.Password,
                DispatchConsumersAsync = true
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += TriggerConsumerReceived;

            channel.BasicConsume(queue: eventName,
                autoAck: true,
                consumer: consumer
            );
        }

        private async Task TriggerConsumerReceived(object sender, BasicDeliverEventArgs ev)
        {
            var eventName = ev.RoutingKey;
            var message = Encoding.UTF8.GetString(ev.Body.Span);

            try {
                await ExecuteEvent(eventName, message).ConfigureAwait(false);
            } catch (Exception ex) { 
                
            }        
        }

        private async Task ExecuteEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptors = _handlers[eventName];
                    foreach (var subscriptor in subscriptors)
                    {
                        var handler = scope.ServiceProvider.GetService(subscriptor);
                        if (handler == null) continue;
                        var eventType = _eventTypes.SingleOrDefault(s => s.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                }
                
            }
        }
    }
}
