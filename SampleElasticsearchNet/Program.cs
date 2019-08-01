using System;

namespace SampleElasticsearchNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Elasticsearch.Net and NEST!");
            //ElasticService.CreateIndexMapping();
            //ElasticService.IndexData();
            ElasticService.QueryMatch("环保除尘",1,20);

        }
    }
}
