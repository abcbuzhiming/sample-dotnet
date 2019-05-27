using System.Collections;
using System.Collections.Generic;
using System;

namespace SampleDotNetApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello SampleDotNetApi!");
            //IList<IDictionary<string,string>> list = new List<IDictionary<string,string>>();
            //GenericTest.testParam(list);

            DynamicTest.dynamicReflece();
        }


    }
}
