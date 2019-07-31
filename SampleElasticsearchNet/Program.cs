using System;

namespace SampleElasticsearchNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Elasticsearch.Net and NEST!");
            ElasticService.CreateIndexMapping();
        }
    }
}
