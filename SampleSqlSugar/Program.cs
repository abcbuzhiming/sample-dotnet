using System.Linq;
using System.IO;
using System;
using System.Collections.Generic;
using SqlSugar;


namespace SampleSqlSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello  SqlSugar Core Orm!");
            test1();
        }

        static void test1(){
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=127.0.0.1;port=3306;uid=sa;pwd=lanshanTest@2018&26g;database=test1",     //连接字符串基于sqlconnection格式
                DbType = DbType.MySql,      //数据库类型
                IsAutoCloseConnection = true,       //自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute     //从实体特性中读取主键自增列信息
            });

            //打印sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

            var list = db.Queryable<Dictionary<string,string>>().ToList();
            Console.WriteLine(list);
        }
    }
}
