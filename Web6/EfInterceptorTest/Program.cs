using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web6.Data;
using Web6.Data.Entities;

class Program
{
    static async Task Main(string[] args)
    {

        IServiceCollection services = new ServiceCollection();
        services.AddDatabase();
        var serviceProvider = services.BuildServiceProvider();

        var context = serviceProvider.GetService<WebContext>();

        //AddStudents(context);

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("With Interceptor....");
        await GetAllStudents(applyInterceptor: true, context);
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine("Without Interceptor....");
        await GetAllStudents(applyInterceptor: false, context);
        Console.WriteLine("---------------------------------------------");
    }

    static void AddStudents(WebContext context)
    {
        context.Add(
            new Student
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "4 Privet Drive",
            });

        context.Add(
            new Student
            {
                FirstName = "Jane",
                LastName = "Doe",
                Address = "4 Privet Drive",
            });
        context.SaveChanges();
    }

    static async Task GetAllStudents(bool applyInterceptor, WebContext context)
    {

        IList<Student> studentCollection = null;
        if (applyInterceptor)
        {
            studentCollection = await context.Students.TagWith("Apply OrderBy DESC").ToListAsync();
        }
        else
        {
            studentCollection = await context.Students.ToListAsync();
        }

        Console.WriteLine("Printing List of Students");
        foreach (var student in studentCollection)
        {
            Console.WriteLine(student);
        }
    }

}