namespace HwPassion.Infrastructure.Caches.Interface
{
    /// <summary>
    /// 缓存键
    /// </summary>
    public interface ICacheKey
    {
        /// <summary>
        /// 获取加工后的键
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        string GetKey(string key);
        /// <summary>
        /// 获取缓存过期标记键
        /// </summary>
        /// <param name="key">缓存键</param>
        string GetSignKey(string key);
    }
}
