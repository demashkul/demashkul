
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


//Console.WriteLine("Hello, World!");

//IServiceCollection services = new ServiceCollection();
//services.AddDatabase();
//var collection =services.BuildServiceProvider();

//var context = collection.GetService<WebContext>();

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
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{

    string message = "";
    channel.QueueDeclare(queue: "hello",
                     durable: false,
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


}
//Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
