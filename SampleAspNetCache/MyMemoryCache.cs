using Microsoft.Extensions.Caching.Memory;

namespace SampleAspNetCache
{

    /// <summary>
    /// 定义一个有大小限制的缓存
    /// </summary>
    public class MyMemoryCache
    {
        public MemoryCache Cache { get; set; }
        public MyMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024        //限制大小为1024。注意这是一个抽象的大小，并没有单位，表示这个缓存里会装入1024单位的缓存，而每个缓存占多少单位由MemoryCacheEntryOptions设置
            });
        }
    }
}