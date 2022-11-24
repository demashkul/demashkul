using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wx.Data.Domain;
using Wx.Infra.DataAccess;

namespace Wx.DataAccess
{
    public class WxContext : DbContext, IDataContext
    {
        public WxContext(DbContextOptions<WxContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
