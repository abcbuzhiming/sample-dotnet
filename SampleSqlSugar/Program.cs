using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System;
using System.Collections.Generic;
using SqlSugar;
using SampleSqlSugar.Entity;


namespace SampleSqlSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello  SqlSugar Core Orm!");
            //test1();
            createEntity();
            //Console.WriteLine(underline2Camel("user_info_ak",true));
        }

        static void test1()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=127.0.0.1;port=3306;uid=sa;pwd=lanshanTest@2018&26g;database=test1",     //连接字符串基于sqlconnection格式(不同数据库格式不同)
                DbType = DbType.MySql,      //数据库类型
                IsAutoCloseConnection = true,       //自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute     //从实体特性中读取主键自增列信息
            });

            //打印sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //Console.WriteLine();
            };

            //动态类型
            /*
            var t12 = db.SqlQueryable<dynamic>("select * from user_info").ToPageList(1, 2);//返回动态类型
            foreach (var obj in t12)
            {
                foreach (var item in (IDictionary<string, object>)obj)
                {
                    Console.Write(item.Key + " : " + item.Value + ", ");
                }
                Console.WriteLine();
            }
             */
            var t12 = db.SqlQueryable<UserInfo>("select * from user_info").ToPageList(1, 2);//返回动态类型
            foreach (var obj in t12)
            {
                Console.WriteLine(obj.rssi);
            }
            
        }

        //生成实体类
        static void createEntity(){
            /*
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=127.0.0.1;port=3306;uid=sa;pwd=lanshanTest@2018&26g;database=test1",     //连接字符串基于sqlconnection格式(不同数据库格式不同)
                DbType = DbType.MySql,      //数据库类型
                IsAutoCloseConnection = true,       //自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute     //从实体特性中读取主键自增列信息
            });
            */

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "datasource=F:/work/YouMingStudio/qay-lottery-choose357-analyse/sql/lottery-choose-analyse.sqlite3",
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute     //从实体特性中读取主键自增列信息
            });

            List <DbTableInfo> dbTableInfoList = db.DbMaintenance.GetTableInfoList(false);
            foreach (var dbTableInfo in dbTableInfoList){
                Console.WriteLine(dbTableInfo.Name);
                var tableName = dbTableInfo.Name;
                var tableNameMapping = underline2Camel(tableName,true);        //表名转换为大驼峰映射
                db.MappingTables.Add(tableNameMapping, tableName);
                List<DbColumnInfo> dbColumnInfoList = db.DbMaintenance.GetColumnInfosByTableName(tableName);
                foreach(var dbColumnInfo in dbColumnInfoList){
                    //Console.WriteLine(dbColumnInfo.DbColumnName);
                    var columnName = dbColumnInfo.DbColumnName;
                    var columnNameMapper = underline2Camel(columnName,true);        //字段名转换为小驼峰映射
                    db.MappingColumns.Add(columnNameMapper, columnName, tableNameMapping);
                }
            }

            //db.MappingTables.Add("userInfo", "user_info");
            //db.MappingColumns.Add("parentId", "parent_id", "userInfo");
            var path1 =  Environment.CurrentDirectory;
            var path2 = Directory.GetCurrentDirectory();
            Console.WriteLine(path1 + " | " + path2);
            var pathEntity = path1 + "/Entity";
            pathEntity = "F:/";
            db.DbFirst.IsCreateAttribute().StringNullable().CreateClassFile(pathEntity,"SampleSqlSugar.Entity");
        }

        static string underline2Camel(string sourceStr,bool bigCamel=false){

            Match mt = Regex.Match(sourceStr, @"_(\w*)*");
            while (mt.Success)
            {
                string item = mt.Value;
                //Console.WriteLine("item:" + item);
                while (item.IndexOf('_') >= 0)
                {
                    string newUpper = item.Substring(item.IndexOf('_'), 2);
                    //Console.WriteLine("newUpper:" + newUpper);
                    item = item.Replace(newUpper, newUpper.Trim('_').ToUpper());
                    sourceStr = sourceStr.Replace(newUpper, newUpper.Trim('_').ToUpper());
                }
                mt = mt.NextMatch();
            }
            if(bigCamel){       //大驼峰,把第一个字符变大
                var firstChar = sourceStr.Substring(0,1).ToUpper();
                sourceStr = firstChar + sourceStr.Substring(1);
            }
            return sourceStr;
        }
    }
}
