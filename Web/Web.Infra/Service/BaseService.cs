using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Infra.DataAccess;
using Web.Infra.Entity;

namespace Web.Infra.Service
{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IDataContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;


        public BaseService(IDataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = (_dbContext as DbContext).Set<TEntity>();

        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDto>> GetAllMappedAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync();
        }

        public Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> select)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
