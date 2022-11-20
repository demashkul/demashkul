
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        //IConfiguration config = new ConfigurationBuilder()
        //    .AddJsonFile("appsettings.json")
        //    .AddEnvironmentVariables()
        //    .Build();
        //IServiceCollection services = new ServiceCollection();
        //services.Configure<string>(config.GetRequiredSection(""));
        string exchangeName = "direct";
        string routex = "saloon.x";
        string routey = "saloon.y";

        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "admin",
            Password = "123456",
        };

        IConnection connection = factory.CreateConnection();
        IModel channel = connection.CreateModel();

        channel.ExchangeDeclare(exchangeName, type: ExchangeType.Direct);
        for (int i = 1; i <= 100; i++)
        {

            byte[] bytemessage = Encoding.UTF8.GetBytes($"{i}. mesaj");

            IBasicProperties properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            if (i % 2 == 0)
            {
                channel.BasicPublish(exchange: exchangeName, routingKey: routex, basicProperties: properties, body: bytemessage);
            }
            else
            {
                channel.BasicPublish(exchange: exchangeName, routingKey: routey, basicProperties: properties, body: bytemessage);
            }
            Thread.Sleep(100);
        }

        Console.WriteLine("Hello, World!");
    }
}