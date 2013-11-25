using System.Linq;
using System;

namespace MoneyHawk.Web.Controllers
{
    using System.Runtime.Caching;

    public class Cache
    {
        private readonly CacheItemPolicy policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromHours(1) };
        private readonly ObjectCache cache = MemoryCache.Default;

        public void Add(string key, object value)
        {
            this.cache.Add(key, value, this.policy);
        }

        public T GetOrAdd<T>(string key, Func<T> initializer) where T : class
        {
            T result;
            if (!this.cache.Contains(key) || (result = (T)this.cache.Get(key)) == null)
            {
                result = initializer();
                this.Add(key, result);
            }
            return result;
        }
    }
}