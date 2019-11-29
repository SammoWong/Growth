using Growth.Domain.Entities;
using Growth.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Growth.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public EntityFrameworkCoreRepository()
        {

        }
        public override int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteSqlCommand(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public override Task ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public override bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void Insert(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public override Task InsertAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public override TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void Update(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }
    }

    public class EntityFrameworkCoreRepository<TEntity, TPrimaryKey> : EntityFrameworkCoreRepository<TEntity>, IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public EntityFrameworkCoreRepository()
        {

        }
        public void Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
