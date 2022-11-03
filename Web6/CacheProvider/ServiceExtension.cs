using CacheProvider.Redis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheProvider
{
    public static class ServiceExtension
    {
        public static void AddRedis(this IServiceCollection service)
        {
            service.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = "127.0.0.1:6379";
                opt.InstanceName = "master";
            });

            service.AddScoped<IRedisProvider,RedisProvider>();
        }
    }
}
