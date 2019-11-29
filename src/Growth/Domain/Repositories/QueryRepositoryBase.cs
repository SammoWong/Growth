using Growth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Growth.Domain.Repositories
{
    public abstract class QueryRepositoryBase<TEntity> : IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        public abstract int Count(Expression<Func<TEntity, bool>> predicate = null);
        public abstract Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
        public abstract bool Exists(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);
        public abstract Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);
        public abstract IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        public abstract IEnumerable<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null);
        public abstract IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null);
    }
}
