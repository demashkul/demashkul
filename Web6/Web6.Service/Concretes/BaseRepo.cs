using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Data;
using Web6.Service.Abstarcts;

namespace Web6.Service.Concretes
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class
    {
        private readonly WebContext _dbContext;

        public BaseRepo(WebContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
