using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Service.Abstracts;
using Web.Service.Concretes;

namespace Web.Service
{
    public static class ServiceExtension
    {
        public static void AddBussServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

        }
    }
}
