using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace SampleAspNetCache.Controllers
{
    /// <summary>
    /// 测试自定义的缓存大小的缓存
    /// </summary>
    [Route("[controller]/[action]")]
    public class SampleTwoController : Controller
    {
        private MemoryCache _cache;

        public SampleTwoController(MyMemoryCache memoryCache)
        {
            _cache = memoryCache.Cache;
        }

        /// <summary>
        /// 范例 hello
        /// </summary>
        public string hello()
        {

            return "sample two hello";
        }

        public string test()
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSize(1)         //当你限制了缓存的单位，则必须设置这个值，它代表一条缓存占多少个单位，比如缓存总单位1024，一条缓存占2个单位，则总共能放入1024/2=512条缓存
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));     //不访问3秒后就过期


            _cache.Set("111", "111",cacheEntryOptions);
            _cache.Set("222", "222",cacheEntryOptions);
            _cache.Set("333", "333",cacheEntryOptions);

            Console.WriteLine(_cache.Get("111"));
            Console.WriteLine(_cache.Get("222"));
            Console.WriteLine(_cache.Get("333"));
            return "sample two test";
        }
    }
}