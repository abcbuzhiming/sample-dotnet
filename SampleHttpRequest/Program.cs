using System;

namespace SampleHttpRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Http Request!");
            SampleHttpClient.samplePost();
            Console.ReadKey();      //等待异步执行完
        }
    }
}
