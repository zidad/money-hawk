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
            if (value == null) throw new ArgumentNullException("value", "value missing for key: " + key);
            cache.Add(key, value, this.policy);
        }

        public T GetOrAdd<T>(string key, Func<T> initializer) where T : class
        {
            T result;
            
            if (cache.Contains(key) && (result = (T) cache.Get(key)) != null) 
                return result;
            
            result = initializer();
            
            Add(key, result);
            
            return result;
        }
    }
}