using System;
using System.Collections;
using System.Collections.Generic;

namespace SampleDotNetApi
{
    /// <summary>
    /// 泛型容器测试
    /// </summary>
    public class GenericTest
    {
        public static void testParam<T>(IList<T> list){
            Console.WriteLine("传入泛型参数成功");
        }
    }
}