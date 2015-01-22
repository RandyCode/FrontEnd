using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Randy.Memcached;

namespace FrontendCore.Cache
{
    public class WebCache : ICache
    {
        private System.Web.Caching.Cache _cache;

        public WebCache()
        {
            if (_cache == null)
                _cache = new System.Web.Caching.Cache();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}
