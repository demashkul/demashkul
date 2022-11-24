using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        // Build a config object, using env vars and JSON providers.
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        //var rabbitConf = builder.Configuration.GetRequiredSection("RabbitConf").Get<RabbitConf>();
        //var settings = config.GetRequiredSection("RabbitConf").Get<RabbitConf>();


        IServiceCollection services = new ServiceCollection();
        //services.AddDatabase();
        //services.AddHttpClients();
        var serviceProvider = services.BuildServiceProvider();

        //var context = serviceProvider.GetService<WebContext>();
        //var client = serviceProvider.GetService<IOpenApi>();
        //var db = context.Message.Add(new Web6.Data.Entities.Message { Content = "Test in Console" });
        //context.SaveChanges();
    }
}