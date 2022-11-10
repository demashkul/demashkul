using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Data.Entities;

namespace Web6.Data
{
    public class WebContext : DbContext, IDataContext
    {
        public WebContext(DbContextOptions<WebContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("")
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Message> Message { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new MyCommandInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
