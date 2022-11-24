using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.DataAccess
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<WxContext>(opt =>
            {
                opt.UseSqlite("Data Source=d:\\MyDb.data");
                //opt.UseSqlServer("Data Source=ip,1434\\instanceName; database=MyData; user id = User; password=123;Connection Timeout = 60;");
            });
        }
    }
}
