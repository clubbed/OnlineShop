using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Caching
{
    public class RedisCacheService : ICacheService //IDistributedCache
    {
        private readonly IDatabase _db;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _db = connectionMultiplexer.GetDatabase();
        }

        //public bool IsConnected()
        //{
        //    return _db.IsConnected();
        //}

        public async Task<bool> DeleteKeyAsync(string key)
        {
            return await _db.KeyDeleteAsync(key);
        }

        public async Task<bool> KeyExistsAsync(string key)
        {
            return await _db.KeyExistsAsync(key);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }
        public async Task<T> GetValueAsync<T>(string key)
        {
            var deserialized = await _db.StringGetAsync(key);

            return JsonConvert.DeserializeObject<T>(deserialized);
        }

        public async Task<bool> SetValueAsync<T>(string key, T value)
        {
            var serialized = JsonConvert.SerializeObject(value);

            return await _db.StringSetAsync(key, serialized);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            return await _db.StringSetAsync(key, value);
        }

        //public byte[] Get(string key)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<byte[]> GetAsync(string key, CancellationToken token = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Refresh(string key)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task RefreshAsync(string key, CancellationToken token = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Remove(string key)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task RemoveAsync(string key, CancellationToken token = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
