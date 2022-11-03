using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ww.Plugin
{
    public static class ServiceExtension
    {
        public static void AddPlugins(this ServiceCollection services)
        {
            services.AddHttpClient("op1", conf =>
            {
                conf.BaseAddress = new Uri("http://localhost/");
            });
        }
    }
}
