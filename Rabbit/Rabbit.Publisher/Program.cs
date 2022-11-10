
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;

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
        string route = "saloon.x";

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
            if (i % 2 == 0)
            {
                route = "saloon.y";
            }
            else
            {
                route = "saloon.x";
            }
            byte[] bytemessage = Encoding.UTF8.GetBytes($"{i}. mesaj");

            //IBasicProperties properties = channel.CreateBasicProperties();
            //properties.Persistent = true;
            //properties.Headers = new Dictionary<string, object>()
            //{
            //    ["no"] = args[0] == "1" ? "123456" : "654321"
            //};


            channel.BasicPublish(exchange: exchangeName, routingKey: route, null, body: bytemessage);
        }


        Console.WriteLine("Hello, World!");
    }
}