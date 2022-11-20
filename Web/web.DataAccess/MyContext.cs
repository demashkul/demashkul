using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Entities;
using Web.Infra.DataAccess;

namespace Web.DataAccess
{
    public class MyContext : DbContext, IDataContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
