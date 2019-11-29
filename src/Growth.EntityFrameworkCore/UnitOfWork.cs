using Growth.Domain;
using Growth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDbContext GetDbContext(Type entityType)
        {
            throw new NotImplementedException();
        }

        public IDbContext GetDbContext<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
