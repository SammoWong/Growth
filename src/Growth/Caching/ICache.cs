using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Caching
{
    public interface ICache
    {
        bool IsExist(string key);

        T Get<T>(string key);

        bool Set<T>(string key, T value, TimeSpan? expiration = null);

        void Remove(string key);

        void Clear();
    }
}
