using System.Dynamic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SampleDotNetApi
{
    /// <summary>
    /// 动态类型测试
    /// 参考 https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject
    /// </summary>
    public class DynamicTest
    {
        /// <summary>
        /// 对动态类型进行反射看效果
        /// </summary>
        public static void dynamicReflece()
        {
            //dynamic d1 = new {aaa = 1, bbb = "我是谁" };      //普通的动态对象可以反射
            //dynamic d1 = new Dictionary<string,object>(){{"station","站点"},{"city","城市"}};       //Dictionary无法反射，会抛异常
            dynamic d1 = new ExpandoObject();       //可以反射，但是拿不到成员，要拿到成员得用别的办法
            d1.aaa = 1;
            reflece(d1);
        }

        public static void reflece(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine("type.Name:" + type.Name);
            if (type == typeof(ExpandoObject))
            {      //ExpandoObject类型无法反射拿到属性值,遍历方法不同
                foreach (var property in (IDictionary<string, object>)obj)
                {
                    //Console.WriteLine(property.Key + ": " + property.Value);
                    string name = property.Key;        //属性名
                    var value = property.Value;       //值
                    Console.WriteLine(name + " -> " + value);

                }
            }
            else
            {
                PropertyInfo[] propertyInfoArray = type.GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfoArray)
                {
                    string name = propertyInfo.Name;        //属性名
                    var value = propertyInfo.GetValue(obj, null);       //值
                    Console.WriteLine(name + " -> " + value);
                }
            }

        }
    }
}