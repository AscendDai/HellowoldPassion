using HwPassion.Infrastructure.Caches.Interface;

namespace HwPassion.Infrastructure.Caches.Redis
{
    /// <summary>
    /// Redis缓存管理器
    /// </summary>
    public class RedisCacheManager : CacheManagerBase
    {
        public RedisCacheManager(ICacheConfig config)
            : base(config)
        {

        }

        public RedisCacheManager(ICacheProvider provider, ICacheKey cacheKey)
            : base(provider, cacheKey)
        {

        }
    }
}
