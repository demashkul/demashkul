using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Web6.Service.Abstarcts
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        #region GetAll
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TDto>> GetAllMappedAsync<TDto>(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> select);


        #endregion

        #region Insert
        void Insert(TEntity entity);
        void InsertMany(IEnumerable<TEntity> entities);
        #endregion

        #region Update
        void Update(TEntity entity);
        void UpdateMany(IEnumerable<TEntity> entities);
        #endregion

        #region Delete
        void Delete(TEntity entity);
        void DeleteMany(IEnumerable<TEntity> entities);
        #endregion
        Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
