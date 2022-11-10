using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web6.Data
{
    public static class ServiceExtension
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<IDataContext, WebContext>(opt =>
            {
                opt.UseSqlite("Data Source=d:\\MyDb.data");
            });
        }
    }
}
