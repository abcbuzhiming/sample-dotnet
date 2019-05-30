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


    [Route("[controller]/[action]")]
    public class SampleController : Controller
    {
        private IMemoryCache _cache;        //系统注入缓存

        public SampleController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <summary>
        /// 范例 hello
        /// </summary>
        public string hello()
        {

            return "sample hello";
        }

        /// <summary>
        /// 最简单的获取缓存的方式
        /// </summary>
        /// <returns></returns>
        public string get(){
            string value = _cache.Get<string>("aaa");
            return "value:" + value;
        }

        /// <summary>
        /// 尝试获取缓存，如果不存在则手动新建缓存
        /// </summary>
        /// <returns></returns>
        public string tryGetValue()
        {
            var key = "aaa";
            string value;
            //查找换船
            if (!_cache.TryGetValue(key, out value))
            {
                //缓存不存在
                value = DateTime.Now.ToString();
                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));     //不访问3秒后就过期
                                                                        // Save data in cache.
                _cache.Set(key, value, cacheEntryOptions);
            }
            return value;
        }

        /// <summary>
        /// 获取缓存，如果不存在则使用lamba自动创建缓存
        /// </summary>
        /// <returns></returns>
        public string getOrCreate(){
            var value = _cache.GetOrCreate("aaa", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);  //不访问3秒后就过期
                return DateTime.Now.ToString();     //这个值会被设定为缓存，并交给value
            });
            return value;
        }

        /// <summary>
        /// 获取缓存，如果不存在则使用lamba自动创建缓存。这种异步执行的，lamba可以执行很长的时间
        /// </summary>
        /// <returns></returns>
        public async  Task<string> getOrCreateAsync(){
            var value = await _cache.GetOrCreateAsync("aaa", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);  //不访问3秒后就过期
                return Task.FromResult(DateTime.Now.ToString());     //这个值会被设定为缓存，并交给value
            });
            return value;
        }
    }
}