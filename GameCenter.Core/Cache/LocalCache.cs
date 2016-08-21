using GameCenter.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Cache
{
    public class LocalCache 
    {
        private volatile static LocalCache _instance = null;
        private static readonly object lockHelper = new object();
        private LocalCache() { }
        public static LocalCache Instance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new LocalCache();
                }
            }
            return _instance;
        }

        private MemoryCache _memoryCache
        {
            get { return MemoryCache.Default; }
        } 

        public T Get<T>(string key)
        {
            if (_memoryCache.Contains(key))
            {
                return (T)_memoryCache.GetCacheItem(key).Value;
            }
            return default(T);
        }

        //public void Set<T>(string key, T t, TimeSpan expires)
        //{
        //    //创建缓存策略
        //    CacheItemPolicy policy = new CacheItemPolicy();
        //    //缓存优先级
        //    policy.Priority = CacheItemPriority.Default;
        //    policy.SlidingExpiration = expires; 
        //    _memoryCache.Set(key, t, policy);
        //}

        public void Set<T>(string key, T t, DateTime expires)
        {
            //创建缓存策略
            CacheItemPolicy policy = new CacheItemPolicy();
            //缓存优先级
            policy.Priority = CacheItemPriority.Default;
            policy.AbsoluteExpiration = expires;
            _memoryCache.Set(key, t, policy);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
 
    }
}
