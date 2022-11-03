using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Ww.RConsumer5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                ContinuationTimeout = new TimeSpan(0, 2, 0),
                SocketReadTimeout = new TimeSpan(0, 2, 0),
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

                string message = "";
                channel.QueueDeclare(queue: "hello",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);



                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

            //Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
