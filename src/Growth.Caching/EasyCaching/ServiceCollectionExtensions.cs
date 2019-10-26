using EasyCaching.Core;
using EasyCaching.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Growth.Caching.EasyCaching
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCache(this IServiceCollection services, Action<EasyCachingOptions> options)
        {
            services.TryAddScoped<ICache, CacheManager>();
            services.AddEasyCaching(options);
        }
    }
}
