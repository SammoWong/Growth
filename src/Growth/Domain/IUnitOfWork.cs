using Growth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();

        /// <summary>
        /// 根据实体类型获取数据库上下文
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        IDbContext GetDbContext(Type entityType);

        /// <summary>
        /// 根据实体获取数据库上下文
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        IDbContext GetDbContext<TEntity, TKey>() where TEntity : IEntity<TKey>;
    }
}
