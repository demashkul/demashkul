using Microsoft.Extensions.DependencyInjection;
using Web.Service.Concretes;
using Web6.Service.Abstracts;

namespace Web.Service
{
    public static class ServiceExtension
    {
        public static void AddBussServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

        }
    }
}
