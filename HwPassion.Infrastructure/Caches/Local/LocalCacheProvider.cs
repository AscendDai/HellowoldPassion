using System;
using System.Web;
using System.Web.Caching;
using HwPassion.Infrastructure.Caches.Interface;

namespace HwPassion.Infrastructure.Caches.Local
{
    /// <summary>
    /// 本地缓存提供程序
    /// </summary>
    public class LocalCacheProvider : CacheProviderBase
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">值</param>
        /// <param name="time">过期时间，单位：秒,0为永不过期</param>
        protected override void AddCache(string key, object target, int time)
        {
            HttpRuntime.Cache.Insert(key, target, null, DateTime.Now.AddSeconds(time), Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">缓存对象</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        protected override T GetCache<T>(string key)
        {
            return Conv.To<T>(HttpRuntime.Cache.Get(key));
        }

        /// <summary>
        /// 更新缓存,当key不存在则不添加
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">值</param>
        /// <param name="time">过期时间，单位：秒,0为永不过期</param>
        protected override void UpdateCache(string key, object target, int time)
        {
            HttpRuntime.Cache.Insert(key, target, null, DateTime.Now.AddSeconds(time), Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        protected override void RemoveCache(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        /// <summary>
        /// 清除全部缓存
        /// </summary>
        public override void Clear()
        {
            var enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Remove(enumerator.Key.ToString());
            }
        }
    }
}
