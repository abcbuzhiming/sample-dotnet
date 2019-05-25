using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SampleJson
{
    /// <summary>
    /// Newtonsoft.Json的工具类
    /// </summary>
    public class NewtonsoftJsonUtil
    {

        /// <summary>
        /// 序列化范例
        /// </summary>
        public static void sampleSer(){
            string json = null;
            //键值对的序列化
            IDictionary dictionary = new Dictionary<string,object>();
            dictionary.Add("key1",1);
            dictionary.Add("key2","我了个去");
            dictionary.Add("key3",0.123);
            dictionary.Add("key_abc",2);
            dictionary.Add("keyValue",3);
            dictionary.Add("KeyValue",4);
            dictionary.Add("time",DateTime.Now);

            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            json = JsonConvert.SerializeObject(dictionary,timeConverter);
            Console.WriteLine("N json:" + json);

        }


        /// <summary>
        /// 反序列化范例
        /// </summary>
        public static void sampleDeser(){
            string json = @"[{'key1':1,key2:'我'},{'key1':2,key2:'它'}]";
            IList<Dictionary<string,object>> list = JsonConvert.DeserializeObject<IList<Dictionary<string,object>>>(json);
            foreach(Dictionary<string,object> dictionary in list){
                Console.WriteLine(dictionary["key1"] + "|" + dictionary["key2"]);
            }
        }
    }
}