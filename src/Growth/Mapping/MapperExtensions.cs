using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Growth.Mapping
{
    public static class MapperExtensions
    {
        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object Sync = new object();
        /// <summary>
        /// 配置提供器
        /// </summary>
        private static IConfigurationProvider _config;

        /// <summary>
        /// 将源对象映射为目标对象
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TTarget MapTo<TTarget>(this object source) where TTarget : new()
        {
            return MapTo(source, new TTarget());
        }

        /// <summary>
        /// 将源对象映射为目标对象
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static TTarget MapTo<TSource, TTarget>(this TSource source, TTarget target)
        {
            return MapTo<TTarget>(source, target);
        }

        /// <summary>
        /// 将源对象映射为目标对象
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static TTarget MapTo<TTarget>(object source, TTarget target)
        {
            if (source == null || target == null)
                return default;

            var sourceType = GetType(source);
            var targetType = GetType(target);
            if (!IsExist(sourceType, targetType))
            {
                lock (Sync)
                {
                    if (IsExist(sourceType, targetType))
                        return GetResult(source, target);

                    Init(sourceType, targetType);
                }
            }

            return GetResult(source, target);
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static Type GetType(object obj)
        {
            var type = obj.GetType();
            if (type.IsArray)
                return type.GetElementType();

            if (obj is IEnumerable == false)
                return type;

            var genericArgumentsTypes = type.GetGenericArguments();
            if (genericArgumentsTypes == null || genericArgumentsTypes.Length == 0)
                throw new ArgumentException("泛型类型参数不能为空");

            return genericArgumentsTypes[0];
        }

        /// <summary>
        /// 是否存在映射配置
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private static bool IsExist(Type sourceType, Type targetType)
        {
            return _config?.FindTypeMapFor(sourceType, targetType) != null;
        }

        /// <summary>
        /// 获取映射结果
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static TTarget GetResult<TTarget>(object source, TTarget target)
        {
            return new Mapper(_config).Map(source, target);
        }

        /// <summary>
        /// 初始化映射配置
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        private static void Init(Type sourceType, Type targetType)
        {
            if(_config == null)
            {
                _config = new MapperConfiguration(c => c.CreateMap(sourceType, targetType));
                return;
            }
            var maps = _config.GetAllTypeMaps();
            _config = new MapperConfiguration(c => c.CreateMap(sourceType, targetType));
            foreach (var map in maps)
            {
                _config.RegisterTypeMap(map);
            }
        }
    }
}
