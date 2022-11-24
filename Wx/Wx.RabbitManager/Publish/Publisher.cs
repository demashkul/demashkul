using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.RabbitManager.Publish
{
    public class Publisher
    {
        public Publisher()
        {

        }
        string directexchange = "directexchange";
        public void PublishToExchange()
        {
            using var channel = new ModelFactory().CreateChannel();
            //IConnection connection = factory.CreateConnection();
            //IModel channel = connection.CreateModel();

            channel.ExchangeDeclare(directexchange, type: ExchangeType.Direct);
            for (int i = 1; i <= 100; i++)
            {
                byte[] bytemessage = Encoding.UTF8.GetBytes($"sayı - {i}");

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                if (i % 2 != 0)
                    channel.BasicPublish(exchange: directexchange, routingKey: "saloon.x", basicProperties: properties, body: bytemessage);
                else
                    channel.BasicPublish(exchange: directexchange, routingKey: "saloon.y", basicProperties: properties, body: bytemessage);
                Thread.Sleep(100);

            }

        }
    }
}
