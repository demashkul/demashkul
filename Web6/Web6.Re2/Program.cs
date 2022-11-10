using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        ServiceCollection services=new ServiceCollection();
        
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        //var a = serviceProvider.GetService<Program>();
        Console.WriteLine("Hello, World!");
    }
}