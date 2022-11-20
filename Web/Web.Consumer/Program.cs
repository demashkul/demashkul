using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Common.Confs;
using System.Data;
using Web.Consumer;

internal class Program
{
    private static void Main(string[] args)
    {

        //IConfiguration config = new ConfigurationBuilder()
        //    .AddJsonFile("appsettings.json")
        //    .AddEnvironmentVariables()
        //    .Build();

        //////var rabbitConf = builder.Configuration.GetRequiredSection("RabbitConf").Get<RabbitConf>();
        ////var settings = config.GetRequiredSection("RabbitConf").Get<RabbitConf>();


        //IServiceCollection services = new ServiceCollection();
        //services.Configure<RabbitConfs>(config.GetRequiredSection(""));
        ////services.AddDatabase();
        ////services.AddHttpClients();
        //var collection = services.BuildServiceProvider();
        //var aa =collection.GetRequiredService<RabbitConfs>();


        //var context = collection.GetService<WebContext>();
        //var client = collection.GetService<IOpenApi>();
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "admin",
            Password = "123456",
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        DirectExchangeConsumer.Consume(channel, args[0]);
        Console.WriteLine("Hello, World!");

        //ConnectionFactory factory = new ConnectionFactory()
        //{
        //    HostName= "localhost",
        //    UserName="admin",
        //    Password="123456",
        //};

        //string route = "";
        //using (IConnection connection = factory.CreateConnection())
        //using (IModel channel = connection.CreateModel())
        //{
        //    channel.ExchangeDeclare("directexchange", type: ExchangeType.Direct);

        //    route = "saloon." + route;
        //    string exchangeName = "direct";
        //    string queueName = "queue" + route;
        //    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);

        //    channel.QueueDeclare(queueName,
        //     durable: true,
        //     exclusive: false,
        //     autoDelete: false,
        //     arguments: null);


        //    if (int.Parse(args[0]) == 1)
        //        channel.QueueBind(queue: queueName, exchange: "directexchange", routingKey: "teksayilar");
        //    else
        //        channel.QueueBind(queue: queueName, exchange: "directexchange", routingKey: "ciftsayilar");

        //    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        //    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
        //    channel.BasicConsume(queueName, false, consumer);
        //    consumer.Received += (sender, e) =>
        //    {
        //        Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()) + " sayısı alındı.");
        //        channel.BasicAck(e.DeliveryTag, false);
        //    };


        //    Console.Read();
        //}
    }
}