using HwPassion.Infrastructure.Caches.Interface;

namespace HwPassion.Infrastructure.Caches.Local
{
    /// <summary>
    /// 本地缓存键
    /// </summary>
    public class LocalCacheKey : ICacheKey
    {
        /// <summary>
        /// 获取缓存键
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public string GetKey(string key)
        {
            return string.Format("Local_{0}", key);
        }

        /// <summary>
        /// 获取缓存过期标记键
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public string GetSignKey(string key)
        {
            return string.Format("Local_Sign_{0}", key);
        }
    }
}
