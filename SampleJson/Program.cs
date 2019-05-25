using System;

namespace SampleJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Json!");
            NewtonsoftJsonUtil.sampleSer();
            NewtonsoftJsonUtil.sampleDeser();
            //JilJsonUtil.sampleSer();
            //JilJsonUtil.sampleDeser();
        }
    }
}
