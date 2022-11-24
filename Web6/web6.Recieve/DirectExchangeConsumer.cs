using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Common.Dtos;

namespace web6.Recieve
{
    public class DirectExchangeConsumer
    {
        public static void Consume(IModel channel, string route)
        {
            route = "saloon." + route;
            string exchangeName = "directexchange";
            string qName = "queue" + route;
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(qName,
             durable: true,
             exclusive: false,
             autoDelete: false,
             arguments: null);

            channel.QueueBind(qName, exchangeName, route);
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                //var dto = System.Text.Json.JsonSerializer.Deserialize<MessageDto>(Encoding.UTF8.GetString(body));

                Console.WriteLine(message);
            };

            channel.BasicConsume(qName, true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}
