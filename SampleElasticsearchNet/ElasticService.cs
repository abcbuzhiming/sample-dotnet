using System.Collections.Generic;
using System;
using System.Linq;
using Elasticsearch.Net;
using Nest;
using SampleElasticsearchNet.Models;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SampleElasticsearchNet
{
    public class ElasticService
    {
        private static ElasticLowLevelClient elasticLowLevelClient;     //Elasticsearch.Net Low level client
        private static ElasticClient elasticClient;     //NEST High level client 推荐

        //初始化连接
        static ElasticService()
        {
            var node = new Uri("http://elastic.lanshan.com:85");
            var settings = new ConnectionSettings(node)
                            .BasicAuthentication("admin", "eck2019@86h96#AC")       //接口使用了http basic auth
                            .DisableDirectStreaming(true);       //调试时打开，能够保留请求RequestBody和ResponseBody供打印输出，影响性能
            elasticLowLevelClient = new ElasticLowLevelClient(settings);
            elasticClient = new ElasticClient(settings);
        }


        /// <summary>
        /// 创建索引，并设置mapping
        /// </summary>
        public static void CreateIndexMapping()
        {
            /*
            var createIndexResponse = elasticClient.Indices.Create("user_info", c => c
                .Map<UserInfo>(mm => mm
                    .Properties(ps => ps
                        .Text(t => t
                            .Name(n => n.FirstName)
                            .Analyzer("ik_smart")
                        )
                        .Text(t => t
                            .Name(n => n.LastName)
                            .Analyzer("ik_smart")
                        )
                        .Date(
                            t => t
                            .Name(n => n.Birthday)
                            .Format("yyyy-MM-dd HH:mm:ss.SSS")
                        )
                        .Keyword(t => t
                            .Name(n => n.Phone)
                        )
                    )
                )
            );
             */
            var createIndexResponse = elasticClient.Indices.Create("baobiao_ik", c => c
                .Map<TenderBidData>(mm => mm
                    .Properties(ps => ps
                        .Keyword(t => t
                            .Name(n => n.ProjectId)
                        ).Date(
                            t => t
                            .Name(n => n.CreateTime)
                            .Format("yyyy-MM-dd HH:mm:ss.SSS")
                        )

                        .Text(t => t
                            .Name(n => n.Title)
                            .Analyzer("ik_smart")
                        )
                        .Text(t => t
                            .Name(n => n.Content)
                            .Analyzer("ik_smart")
                        )
                    )
                )
            );

            Console.WriteLine("REST uri:" + createIndexResponse.ApiCall);        //看到请求的url和返回状态
            Console.WriteLine("request body: " + Encoding.UTF8.GetString(createIndexResponse.ApiCall.RequestBodyInBytes));       //影响性能，必须开ConnectionSettings(node).DisableDirectStreaming(true)，否则为null打印失败

            if (!createIndexResponse.IsValid)
            {
                // If the request isn't valid, we can take action here
                Console.WriteLine(createIndexResponse.ServerError.ToString());
            }
        }


        /// <summary>
        /// 添加数据
        /// </summary>
        public static void IndexData()
        {
            var userInfo = new UserInfo
            {
                FirstName = "啊但是大所",
                LastName = "asdasd",
                Birthday = "1990-01-01 10:00:01.234",
                Phone = "15871254687"
            };

            var indexResponse = elasticClient.Index(userInfo, i => i.Index("users"));

            Console.WriteLine("REST uri:" + indexResponse.ApiCall);        //看到请求的url和返回状态
            Console.WriteLine("request body: " + Encoding.UTF8.GetString(indexResponse.ApiCall.RequestBodyInBytes));       //影响性能，必须开ConnectionSettings(node).DisableDirectStreaming(true)，否则为null打印失败

            if (!indexResponse.IsValid)
            {
                // If the request isn't valid, we can take action here
                Console.WriteLine(indexResponse.ServerError.ToString());
            }
        }


        /// <summary>
        /// 查询，match query
        /// </summary>
        public static void QueryMatch(string searchStr, int fromIndex, int pageSize)
        {

            var searchResponse = elasticClient.Search<TenderBidData>(s => s
                .Index("baobiao_ik")        //指定要搜索的索引名称，可以多个
                .Source(src => src.Includes(i => i.Fields(p => p.ProjectId, p => p.CreateTime, p => p.Title)))
                .From(fromIndex).Size(pageSize)     //分页
                .Sort(ss => ss.Descending(p => p.CreateTime))       //根据时间反向排序
                .TrackScores(true)      //为了现实score
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Title)
                        .Query(searchStr)
                    )
                )
                .Highlight(h => h           //高亮
                    .PreTags("<font color=red>")
                    .PostTags("</font>")
                    .Encoder(HighlighterEncoder.Html)
                    .Fields(
                        fs => fs.Field(p => p.Title)
                    )
                )

            );


            Console.WriteLine("REST uri:" + searchResponse.ApiCall);        //看到请求的url和返回状态
            var requestBody = Encoding.UTF8.GetString(searchResponse.ApiCall.RequestBodyInBytes);   //影响性能，必须开ConnectionSettings(node).DisableDirectStreaming(true)，否则为null
            //Console.WriteLine("request body: " + requestBody);       
            var jsonObj = JsonConvert.DeserializeObject(requestBody);       //对json重新格式化
            var requestBodyFormat = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            Console.WriteLine(requestBodyFormat);             



            if (!searchResponse.IsValid)        //判断是否出错出错
            {
                // If the request isn't valid, we can take action here
                Console.WriteLine(searchResponse.DebugInformation.ToString());
                return;
            }

            //var searchResult = searchResponse.Documents;        //这里面是source字段的数据
            bool boolTimeOut = searchResponse.TimedOut;     //是否超时
            var tookTime = searchResponse.Took;     //花费时间毫秒
            var total = searchResponse.Total;   //总计
            var hits = searchResponse.Hits;     //命中数据

            foreach (var hit in hits)
            {
                var score = hit.Score;      //得分
                var projectId = hit.Source.ProjectId;
                var createTime = hit.Source.CreateTime;
                var title = hit.Highlight["title"].First();       //高亮数据
                Console.WriteLine("projectId:{1};createTime:{2};score:{3};title:{0}", title, projectId, createTime, score);
            }


        }
    }
}