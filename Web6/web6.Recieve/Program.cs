// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using web6.Recieve;
using Web6.Common.Confs;
using Web6.Common.Dtos;
using Web6.Data;
using Web6.Plugin;
using Web6.Plugin.Abstracts;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //using IHost host = Host.CreateDefaultBuilder(args).Build();

        // Build a config object, using env vars and JSON providers.
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        //var rabbitConf = builder.Configuration.GetRequiredSection("RabbitConf").Get<RabbitConf>();
        var settings = config.GetRequiredSection("RabbitConf").Get<RabbitConf>();


        IServiceCollection services = new ServiceCollection();
        services.Configure<RabbitConf>(config.GetRequiredSection("RabbitConf"));
        services.AddDatabase();
        services.AddHttpClients();
        var serviceProvider = services.BuildServiceProvider();

        var context = serviceProvider.GetService<WebContext>();
        var client = serviceProvider.GetService<IOpenApi>();
        //var db = context.Message.Add(new Web6.Data.Entities.Message { Content = "Test in Console" });
        //context.SaveChanges();

        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "admin",
            Password = "123456",
            ContinuationTimeout = new TimeSpan(0, 2, 0),
            SocketReadTimeout = new TimeSpan(0, 2, 0),
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        DirectExchangeConsumer.Consume(channel, args[0]);

        QueBuild(channel, "q1", serviceProvider);
        QueBuild(channel, "q2", serviceProvider);
        //Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
        //await host.RunAsync();

    }
    private static void QueBuild(IModel channel, string queueName, ServiceProvider serviceProvider)
    {
        channel.QueueDeclare(queue: queueName,
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var dto = System.Text.Json.JsonSerializer.Deserialize<MessageDto>(Encoding.UTF8.GetString(body));

            //client.CallService("123");
            (new Operation(serviceProvider)).Execute(dto);

            //channel.BasicAck(ea.DeliveryTag, false, true);
            channel.BasicAck(ea.DeliveryTag, true);

            Console.WriteLine(" [x] Received {0} {1}", dto?.Title, queueName);
        };
        channel.BasicConsume(queue: queueName,
                             autoAck: false,
                             consumer: consumer);


    }

}