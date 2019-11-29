using Growth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Domain.Repositories
{
    public interface IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        #region 同步方法
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        bool Exists(Expression<Func<TEntity, bool>> predicate);

        int Count(Expression<Func<TEntity, bool>> predicate = null);
        #endregion

        #region 异步方法
        IEnumerable<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
        #endregion
    }
}
