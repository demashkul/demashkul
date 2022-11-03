﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheProvider.Redis
{
    public interface IRedisProvider
    {
        Task<string> GetAsync(string key);

        Task SetAsync(string key, string value);

    }
}
