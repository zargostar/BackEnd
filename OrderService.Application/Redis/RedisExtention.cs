using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderService.Application.Redis
{
    public static  class RedisExtention
    {
        private static JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        public  static async Task<T>  SetAsync<T>(this IDistributedCache cache,string key,T value,
            DistributedCacheEntryOptions options=null)
        {
            if(options is null)
            {
                options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1));
            }
            var json = JsonSerializer.Serialize(value);
            var bytes = Encoding.UTF8.GetBytes(json);
            await cache.SetAsync(key, bytes, options);
            return value;

        }


        public static  bool TryGetValue<T>(this IDistributedCache cache ,string key, out T? value)
        {
            value = default;
          var result=  cache.Get(key);
            if (result == null) return false;
            try
            {
                value = JsonSerializer.Deserialize<T>(result, serializerOptions);
                return true;


            }
            catch (Exception ex) 
            {
                return false;
            }


        }
        public static async Task<T> GetSet<T>(this IDistributedCache cache, string key,Func<Task<T>> task, DistributedCacheEntryOptions options = null)
        {
           var result= TryGetValue<T>(cache, key,out T? value);
            if (result)
            {
                return value;
            }
            var data = await task();
            if (data != null) {
               await SetAsync(cache, key, data,options);
            }
            return data;



        }

    }
}
