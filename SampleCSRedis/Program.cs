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
            //testList(csredis);
            //testSet(csredis);
            //testZSet(csredis);
            //testHash(csredis);
            testGeo(csredis);
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

        /// <summary>
        /// set操作
        /// </summary>
        static void testSet(CSRedisClient csredis){
            RedisHelper.Initialization(csredis);
            string key = "set";
            RedisHelper.SAdd(key,"mysql");
            RedisHelper.SAdd(key,"postgresql");
            RedisHelper.SAdd(key,"oracle");
            RedisHelper.SAdd(key,"mysql");
            var arr = RedisHelper.SMembers(key);
            foreach(string value in arr){
                Console.WriteLine("value:" + value);
            }
        }
        /// <summary>
        /// zset操作
        /// </summary>
        static void testZSet(CSRedisClient csredis){
            RedisHelper.Initialization(csredis);
            string key = "zset";
            RedisHelper.ZAdd (key,(2,"mysql"));
            RedisHelper.ZAdd (key,(1,"postgresql"));
            RedisHelper.ZAdd (key,(3,"oracle"));
            var arr = RedisHelper.ZRange(key,0,-1);
            foreach(string value in arr){
                Console.WriteLine("value:" + value);
            }
        }


        /// <summary>
        /// hash操作
        /// </summary>
        static void testHash(CSRedisClient csredis){
            RedisHelper.Initialization(csredis);
            string key = "hash";
            RedisHelper.HMSet(key,"name","xiaw");
            RedisHelper.HMSet(key,"age",16);
            var arr = RedisHelper.HMGet(key,"name","age");
            foreach(string value in arr){
                Console.WriteLine("value:" + value);
            }
        }

        /// <summary>
        /// geo操作,redis 3.2后增加的地图坐标
        /// </summary>
        static void testGeo(CSRedisClient csredis){
            RedisHelper.Initialization(csredis);
            string key = "geo";
            RedisHelper.GeoAdd(key,0.01,0.02,"member1");        //坐标member1 经度 纬度
            RedisHelper.GeoAdd(key,0.03,0.04,"member2");        //坐标member2 经度 纬度
 
            Console.WriteLine("距离:" + RedisHelper.GeoDist(key,"member1","member2",GeoUnit.m));
            
            
        }
    }
}
