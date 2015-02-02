using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Randy.Memcached;
using System.Configuration;

namespace FrontendCore.Cache
{
    public class CacheFactory
    {
        public static ICache CreateCache()
        {
            var nodes = ConfigurationManager.AppSettings["memcachedNodes"];
            if (nodes == null)
                return new WebCache();
            else
                return new MemCache();
        }
    }
}
