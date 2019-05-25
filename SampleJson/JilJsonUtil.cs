using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
using Jil;

namespace SampleJson
{
    /// <summary>
    /// Jil Json的工具类
    /// </summary>
    public class JilJsonUtil
    {
        /// <summary>
        /// 序列化范例
        /// </summary>
        public static void sampleSer(){
            string json = null;
            //键值对的序列化,注意，Jil只能序列化有明确类型的值，它无法推断类型，也无法序列化object，这是最大的弱点
            //https://github.com/kevin-montrose/Jil/wiki/Common-Pitfalls#base-classes-as-member-types
            IDictionary<string,object> dictionary = new Dictionary<string,object>();
            dictionary.Add("key1",1);
            dictionary.Add("key2","我了个去");
            //dictionary.Add("key3",0.123);
            //dictionary.Add("key_abc",2);
            //dictionary.Add("keyValue",3);
            //dictionary.Add("KeyValue",4);
            //dictionary.Add("time",DateTime.Now);
            
            json = JSON.Serialize<IDictionary<string,object>>(dictionary);
            Console.WriteLine("J json:" + json);
        }


        /// <summary>
        /// 反序列化范例
        /// </summary>
        public static void sampleDeser(){

        }
    }
}