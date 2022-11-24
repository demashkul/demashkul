using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Web6.Infra.DataAccess;

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

            //NpgSql
            //services.AddDbContext<IDataContext, WebContext>(opt =>
            //{
            //    opt.UseNpgsql("Host=xx;Database=xx;Username=xx;Password=xx;Persist Security Info=true;");
            //});
        }
    }
}
