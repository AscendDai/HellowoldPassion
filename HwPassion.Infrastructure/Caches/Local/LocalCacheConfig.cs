using HwPassion.Infrastructure.Caches.Interface;

namespace HwPassion.Infrastructure.Caches.Local
{
    /// <summary>
    /// 本地缓存配置类
    /// </summary>
    public class LocalCacheConfig : ICacheConfig
    {
        /// <summary>
        /// 获取提供程序
        /// </summary>
        /// <returns></returns>
        public ICacheProvider GetProvider()
        {
            return new LocalCacheProvider();
        }

        /// <summary>
        /// 获取包装key
        /// </summary>
        /// <returns></returns>
        public ICacheKey GetKey()
        {
            return new LocalCacheKey();
        }
    }
}
