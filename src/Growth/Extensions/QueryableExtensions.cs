using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Growth.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return condition ? source.Where(predicate) : source;
        }
    }
}
