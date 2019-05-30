using System;
using CSRedis;

namespace SampleCSRedis
{
    class Program
    {
        //这东西的方法遵循和redis-cli一样的命名和功能
        static void Main(string[] args)
        {
            Console.WriteLine("Hello CSRedis!");
            var csredis = getRedisClient();

            //testKeyValue(csredis);
            testList(csredis);
        }

        static CSRedisClient getRedisClient(){
            //注意csredis应该是个单例模式
            var csredis = new CSRedis.CSRedisClient("127.0.0.1:6379,password=123,defaultDatabase=0,poolsize=10");
            return csredis;
        }

        //基本数据读写
        static void testKeyValue(CSRedisClient csredis){
            RedisHelper.Initialization(csredis);
            RedisHelper.Set("test1", "123123", 60);
            var value = RedisHelper.Get("test1");
            Console.WriteLine("value:" + value);
        }
        

        /// <summary>
        /// list操作
        /// </summary>
        /// <param name="csredis"></param>
        static void testList(CSRedisClient csredis){
            RedisHelper.Initialization(csredis);
            string key = "list";
            RedisHelper.LPush(key,"left 1");
            RedisHelper.LPush(key,"left 2");
            RedisHelper.LPush(key,"left 3");
            RedisHelper.RPush(key,"right 1");
            RedisHelper.RPush(key,"right 2");
            RedisHelper.RPush(key,"right 3");

            var arr = RedisHelper.LRange(key,0,-1);
            foreach(string value in arr){
                Console.WriteLine("value:" + value);
            }
            

        }
    }
}
