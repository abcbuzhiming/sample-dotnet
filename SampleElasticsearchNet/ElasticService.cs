using System.Collections.Generic;
using System;
using Elasticsearch.Net;
using Nest;
using SampleElasticsearchNet.Models;

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
            var settings = new ConnectionSettings(node).BasicAuthentication("admin", "eck2019@86h96#AC");       //接口使用了http basic auth
            elasticLowLevelClient = new ElasticLowLevelClient(settings);
            elasticClient = new ElasticClient(settings);
        }


        /// <summary>
        /// 创建索引，并设置mapping
        /// </summary>
        public static void CreateIndexMapping(){
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
            if (!createIndexResponse.IsValid)
            {
                // If the request isn't valid, we can take action here
                Console.WriteLine(createIndexResponse.ServerError.ToString());
            }
        }


        /// <summary>
        /// 添加输入局
        /// </summary>
        public static void ImportData()
        {
            var userInfo = new UserInfo
            {
                FirstName = "啊但是大所",
                LastName = "asdasd",
                Birthday = "1990-01-01 10:00:01.234",
                Phone = "15871254687"
            };

            var indexResponse = elasticClient.Index(userInfo, i => i.Index("baobiao_ik"));
            if (!indexResponse.IsValid)
            {
                // If the request isn't valid, we can take action here
                Console.WriteLine(indexResponse.ServerError.ToString());
            }
        }
    }
}