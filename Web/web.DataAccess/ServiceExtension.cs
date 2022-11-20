using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess;
using Web.Infra.DataAccess;

namespace Web.Data
{
    public static class ServiceExtension
    {
        public static void AddMyDataBase(this IServiceCollection services)
        {
            services.AddDbContext<IDataContext, MyContext>(opt =>
            {
                opt.UseSqlite("d:\\MySome.data");
            });
        }
    }
}
