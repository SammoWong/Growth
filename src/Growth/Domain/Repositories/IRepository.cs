using Growth.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Growth.Domain.Repositories
{
    public interface IRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        #region 同步方法
        void ExecuteSqlCommand(string sql, params object[] parameters);

        void Insert(params TEntity[] entities);

        void Update(params TEntity[] entities);

        void Delete(params TEntity[] entities);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        TEntity InsertOrUpdate(TEntity entity);
        #endregion

        #region 异步方法
        Task ExecuteSqlCommandAsync(string sql, params object[] parameters);

        Task InsertAsync(params TEntity[] entities);

        Task UpdateAsync(params TEntity[] entities);

        Task DeleteAsync(params TEntity[] entities);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        #endregion
    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository<TEntity> where TEntity : class, IEntity<TPrimaryKey>
    {
        TEntity Get(TPrimaryKey id);

        TPrimaryKey InsertAndGetId(TEntity entity);

        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);

        void Delete(TPrimaryKey id);

        Task<TEntity> GetAsync(TPrimaryKey id);

        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        Task DeleteAsync(TPrimaryKey id);
    }
}
