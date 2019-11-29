using Growth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.EntityFrameworkCore
{
    public abstract class EntityTypeConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>, IEntityRegister
        where TEntity : class, IEntity
    {
        /// <summary>
        /// 获取所属的数据上下文类型，如为null，将使用默认上下文， 否则使用指定类型的上下文类型
        /// </summary>
        public Type DbContextType => null;

        /// <summary>
        /// 获取实体类型
        /// </summary>
        public Type EntityType => typeof(TEntity);

        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        /// <summary>
        /// 将当前实体类映射对象注册到数据上下文模型构建器中
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void RegisterTo(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
