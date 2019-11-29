using Growth.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Growth.Domain.Repositories
{
    public abstract class RepositoryBase<TEntity> : QueryRepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class, IEntity
    {
        public abstract void Delete(params TEntity[] entities);
        public abstract void Delete(Expression<Func<TEntity, bool>> predicate);
        public abstract Task DeleteAsync(params TEntity[] entities);
        public abstract Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract void ExecuteSqlCommand(string sql, params object[] parameters);
        public abstract Task ExecuteSqlCommandAsync(string sql, params object[] parameters);
        public abstract void Insert(params TEntity[] entities);
        public abstract Task InsertAsync(params TEntity[] entities);
        public abstract TEntity InsertOrUpdate(TEntity entity);
        public abstract Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        public abstract void Update(params TEntity[] entities);
        public abstract Task UpdateAsync(params TEntity[] entities);
    }

    public abstract class RepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity>, IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public abstract void Delete(TPrimaryKey id);
        public abstract Task DeleteAsync(TPrimaryKey id);
        public abstract TEntity Get(TPrimaryKey id);
        public abstract Task<TEntity> GetAsync(TPrimaryKey id);
        public abstract TPrimaryKey InsertAndGetId(TEntity entity);
        public abstract Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        public abstract TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        public abstract Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
    }
}
