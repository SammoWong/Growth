using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Caching
{
    public interface ICache
    {
        bool Exists(string cacheKey);

        T Get<T>(string cacheKey);

        void Set<T>(string cacheKey, T value, TimeSpan? expiration = null);

        void Remove(string cacheKey);

        void Clear();
    }
}
