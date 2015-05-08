using HwPassion.Infrastructure.Caches.Interface;

namespace HwPassion.Infrastructure.Caches.Local
{
    /// <summary>
    /// 本地缓存管理器
    /// </summary>
    public class LocalCacheManager : CacheManagerBase
    {
        public LocalCacheManager(ICacheConfig config)
            : base(config)
        {

        }

        public LocalCacheManager(ICacheProvider provider, ICacheKey cacheKey)
            : base(provider, cacheKey)
        {

        }
    }
}
