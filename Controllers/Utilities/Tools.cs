using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Randy.Memcached;
using FrontendCore.Cache;

namespace FrontendCore.Utilities
{
    public static class Tools
    {
        static ICache _distrubutedCache;

        public static ICache DistrubutedCache
        {
            get
            {
                if (_distrubutedCache == null)
                    _distrubutedCache = CacheFactory.CreateCache();
                return Tools._distrubutedCache;
            }
            set { Tools._distrubutedCache = value; }
        }
    }
}
