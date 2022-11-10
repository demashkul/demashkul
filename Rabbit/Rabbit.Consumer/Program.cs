using Rabbit.Consumer;
using RabbitMQ.Client;

internal class Program
{
    private static void Main(string[] args)
    {
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
    }
}