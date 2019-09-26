using Growth.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Growth.Application
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, PageableRequest request, out int total)
            where TSource : class
        {
            total = source.Count();
            var query = source.OrderBy(request.SortField, request.SortDirection).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);
            return query;
        }

        public static PageableResult<TSource> Page<TSource>(this IQueryable<TSource> source, PageableRequest request)
            where TSource : class
        {
            var total = source.Count();
            var items = source.OrderBy(request.SortField, request.SortDirection).ToList();
            return new PageableResult<TSource>(items, total);
        }

        public static PageableResult<TResult> Page<TSource, TResult>(this IQueryable<TSource> source, PageableRequest request,
            Expression<Func<TSource, TResult>> expression)
            where TSource : class
            where TResult : class
        {
            var total = source.Count();
            var items = source.OrderBy(request.SortField, request.SortDirection).Select(expression).ToList();
            return new PageableResult<TResult>(items, total);
        }

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string sortField, ListSortDirection sortDirection)
        {
            var parameterExpression = Expression.Parameter(typeof(TSource), "x");
            Expression conversion = Expression.Convert(Expression.Property(parameterExpression, sortField), typeof(object));
            var keySelector = Expression.Lambda<Func<TSource, object>>(conversion, parameterExpression);
            return sortDirection == ListSortDirection.Ascending ? Queryable.OrderBy(source, keySelector)
                : Queryable.OrderByDescending(source, keySelector);
        }
    }
}
