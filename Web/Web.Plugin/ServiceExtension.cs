
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Web.Plugin
{
    public static class ServiceExtension
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient("api1", conf =>
            {
                conf.BaseAddress = new Uri("http://localhost:14141/");
                conf.DefaultRequestHeaders.Add("CustomHeaderKey", "It-is-a-HttpClientFactory-Sample");
            });
            //services.AddScoped<IOpenApi, OpenApiClient>();
        }
    }
}
