using System;
using Randy.Memcached;
using System.Web;

namespace FrontendCore.Cache
{
    public class WebCache : ICache
    {
        private System.Web.Caching.Cache _cache;

        public WebCache()
        {
            if (_cache == null)
                _cache = HttpRuntime.Cache;
        }

        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        public object Get(string key)
        {
            try
            {
                var obj = _cache.Get(key);
                return obj;
            }
            catch {
                return null;
            }               
        }

        public void Remove(string key)
        {
            try
            {
                _cache.Remove(key);
            }
            catch
            {
                throw new Exception("Cache is not exist this key");
            }            

        }

        public void Store(string key, object value, DateTime expiresAt)
        {
            //绝对过期
            _cache.Insert(key, value, null, expiresAt, System.Web.Caching.Cache.NoSlidingExpiration);
            //滑动过期时间 
            //_cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0));
        }

        public void Store(string key, object value)
        {
            _cache.Insert(key, value);
        }
    }
}
