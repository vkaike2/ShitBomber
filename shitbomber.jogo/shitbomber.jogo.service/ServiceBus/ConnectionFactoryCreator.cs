using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using shitbomber.jogo.domain.Extensions;
using shitbomber.jogo.domain.IServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shitbomber.jogo.service.ServiceBus
{
    public class ConnectionFactoryCreator : IConnectionFactoryCreator
    {
        private ConnectionFactory _connectionFactory;

        public ConnectionFactory Get()
        {
            if (_connectionFactory is null)
            {
                _connectionFactory = new ConnectionFactory()
                {
                    Uri = new Uri("amqp://elujjbaw:tThMp7rpOIAFlIJEDd-Y3eIe_brNJWoX@toad.rmq.cloudamqp.com/elujjbaw")
                };
            }
            return _connectionFactory;
        }

        public void Publish(string queue, object bodyMensage)
        {
            using (var connetion = this.Get().CreateConnection())
            using (var channel = connetion.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.BasicPublish(exchange: "",
                                     routingKey: queue,
                                     basicProperties: null,
                                     body: bodyMensage.Serializer());
            }
        }

        public async Task Subscribe(string queue, Action<byte[]> call)
        {
            IModel channel = this.Get().CreateConnection().CreateModel();

            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                call(ea.Body);
            };

            channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
        }
    }
}
