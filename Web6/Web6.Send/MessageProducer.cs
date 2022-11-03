using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Common.Confs;
using Web6.Common.Dtos;

namespace Web6.Send
{
    public class MessageProducer : IMessageProducer
    {
        private readonly RabbitConf rabbitConf;
        public MessageProducer(IOptions<RabbitConf> options)
        {
            rabbitConf = options.Value;
        }
        public void SendMessage(MessageDto message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: message.Via,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var json = System.Text.Json.JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: message.Via,
                                     basicProperties: null,
                                     body: body);
            }

        }
    }
}
