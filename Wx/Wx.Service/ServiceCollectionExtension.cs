using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wx.Service.Abstracts;
using Wx.Service.Concretes;

namespace Wx.Service
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
