# README
DotNet使用Elasticsearch.Net和NEST客户端访问Elasticsearch的演示范例
所有的索引操作方法都在ElasticService

## 新建索引并设定mappings
* 方法名称：CreateIndexMapping
* 对应REST API如下
```shell
PUT baobiao_ik
{
  "mapping": {
    "properties": {
      "content": {
        "type": "text",
        "analyzer": "ik_smart"
      },
      "createTime": {
        "type": "date",
        "format": "yyyy-MM-dd HH:mm:ss.SSS"
      },
      "projectId": {
        "type": "keyword"
      },
      "title": {
        "type": "text",
        "analyzer": "ik_smart"
      }
    }
  }
}
```