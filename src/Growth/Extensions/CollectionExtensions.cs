using System;
using System.Collections.Generic;
using System.Linq;

namespace Growth.Extensions
{
    public static class CollectionExtensions
    {
        public static T OneOf<T>(this ICollection<T> source)
        {
            var count = source.Count;
            return source.ToList()[new Random().Next(0, count)];
        }

        public static bool AddIf<T>(this ICollection<T> source, Func<T, bool> predicate, T value)
        {
            if (predicate(value))
            {
                source.Add(value);
                return true;
            }
            return false;
        }

        public static void RemoveIf<T>(this ICollection<T> source, Func<T, bool> predicate, T value)
        {
            if (predicate(value))
            {
                source.Remove(value);
            }
        }

        public static void RemoveWhere<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            var list = source.Where(predicate);
            foreach (var item in list)
            {
                source.Remove(item);
            }
        }

        /// <summary>
        /// 比较集合是否相等，集合内容顺序可以不一致
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool Equal<T>(this ICollection<T> source, ICollection<T> target)
        {
            return source.Count == target.Count && source.All(target.Contains);
        }
    }
}