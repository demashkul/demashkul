using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Entities;
using Web.Infra.DataAccess;
using Web.Infra.Service;
using Web.Service.Abstracts;

namespace Web.Service.Concretes
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IDataContext dbContext) : base(dbContext)
        {
        }
    }
}
