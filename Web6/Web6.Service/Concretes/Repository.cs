using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web6.Data;
using Web6.Service.Abstarcts;

namespace Web6.Service.Concretes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDataContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(IDataContext dbContext)
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
