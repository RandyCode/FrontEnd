using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Randy.Memcached;

namespace FrontendCore.Cache
{
    public class CacheFactory
    {
        public static ICache CreateCache()
        {
            return new Memcache();
        }
    }
}
