using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheProvider.Redis
{
    public class RedisProvider: IRedisProvider
    {
        private readonly IDistributedCache distributedCache;

        public RedisProvider(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }
        public async Task<string> GetAsync(string key)
        {
            return await distributedCache.GetStringAsync(key);
        }
        public async Task SetAsync(string key, string value)
        {
            await distributedCache.SetStringAsync(key, value);
        }
    }
}
