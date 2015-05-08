using System;
using HwPassion.Infrastructure.Caches.Interface;
using ServiceStack.Redis;

namespace HwPassion.Infrastructure.Caches.Redis
{
    /// <summary>
    /// Redis缓存提供程序
    /// </summary>
    public class RedisCacheProvider : CacheProviderBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="address">IP地址</param>
        /// <param name="port">端口</param>
        /// <param name="password">密码</param>
        public RedisCacheProvider(string address, int port, string password)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");
            if (_client != null) return;
            _client = new RedisClient(address, port);
            _client.SendTimeout = 3600;//发送超时时间(s)
            _client.RetryTimeout = 3600;//重试超时时间(s)
            _client.RetryCount = 3;//重试次数
            if (!string.IsNullOrWhiteSpace(password))
                _client.Password = password;

        }

        /// <summary>
        /// Redis对象
        /// </summary>
        private readonly RedisClient _client;

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">值</param>
        /// <param name="time">过期时间，单位：秒,0为永不过期</param>
        protected override void AddCache(string key, object target, int time)
        {
            if (time == 0)
            {
                _client.Add(key, target);
                return;
            }
            _client.Add(key, target, DateTime.Now.AddSeconds(time));
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">缓存对象</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        protected override T GetCache<T>(string key)
        {
            return _client.Get<T>(key);
        }

        /// <summary>
        /// 更新缓存,当key不存在则不添加
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">值</param>
        /// <param name="time">过期时间，单位：秒,0为永不过期</param>
        protected override void UpdateCache(string key, object target, int time)
        {
            if (time == 0)
            {
                _client.Replace(key, target);
                return;
            }
            _client.Replace(key, target, DateTime.Now.AddSeconds(time));
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        protected override void RemoveCache(string key)
        {
            _client.Remove(key);
        }

        /// <summary>
        /// 清除全部缓存
        /// </summary>
        public override void Clear()
        {
            _client.FlushDb();
        }
    }
}
