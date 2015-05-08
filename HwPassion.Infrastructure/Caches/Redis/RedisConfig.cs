using HwPassion.Infrastructure.Caches.Interface;

namespace HwPassion.Infrastructure.Caches.Redis
{
    /// <summary>
    /// Redis配置类
    /// </summary>
    public class RedisConfig : ICacheConfig
    {
        private readonly string _address;
        private readonly int _port;
        private readonly string _password;

        public RedisConfig(string address, int port, string password = "")
        {
            _address = address;
            _port = port;
            _password = password;
        }

        /// <summary>
        /// 获取提供程序
        /// </summary>
        /// <returns></returns>
        public ICacheProvider GetProvider()
        {
            return new RedisCacheProvider(_address, _port, _password);
        }

        /// <summary>
        /// 获取包装key
        /// </summary>
        /// <returns></returns>
        public ICacheKey GetKey()
        {
            return new RedisCacheKey();
        }
    }
}
