using Growth.Extensions;
using Growth.Json;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Caching
{
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// 将对象放入缓存中
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public static void Set(this IDistributedCache cache, string key, object value, DistributedCacheEntryOptions options)
        {
            Check.NotNullOrEmpty(key, nameof(key));
            Check.NotNull(value, nameof(value));

            var json = value.ToJson();
            if (options == null)
            {
                cache.SetString(key, json);
            }
            else
            {
                cache.SetString(key, json, options);
            }
        }

        /// <summary>
        /// 将对象放入缓存中
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public static async Task SetAsync(this IDistributedCache cache, string key, object value, DistributedCacheEntryOptions options)
        {
            Check.NotNullOrEmpty(key, nameof(key));
            Check.NotNull(value, nameof(value));

            var json = value.ToJson();
            if (options == null)
            {
                await cache.SetStringAsync(key, json);
            }

            await cache.SetStringAsync(key, json, options);
        }

        public static void Set(this IDistributedCache cache, string key, object value, int expirationSeconds)
        {
            Check.NotNullOrEmpty(key, nameof(key));
            Check.NotNull(value, nameof(value));
            Check.GreaterThan(expirationSeconds, 0, "expirationSeconds error");

            cache.Set(key, value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expirationSeconds)
            });
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, object value, int expirationSeconds)
        {
            Check.NotNullOrEmpty(key, nameof(key));
            Check.NotNull(value, nameof(value));
            Check.GreaterThan(expirationSeconds, 0, "expirationSeconds error");

            await cache.SetAsync(key, value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expirationSeconds)
            });
        }

        /// <summary>
        /// 获取指定键缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this IDistributedCache cache, string key)
        {
            var result = cache.GetString(key);
            return result == null ? default(T) : result.ToObject<T>();
        }

        /// <summary>
        /// 获取指定键缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key)
        {
            var result = await cache.GetStringAsync(key);
            return result == null ? default(T) : result.ToObject<T>();
        }
    }
}
