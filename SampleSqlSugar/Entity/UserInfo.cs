using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SampleSqlSugar.Entity
{
    ///<summary>
    ///用户信息
    ///</summary>
    [SugarTable("user_info")]
    public partial class UserInfo
    {
           public UserInfo(){


           }
           /// <summary>
           /// Desc:id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:介绍者id,没有为0
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="parent_id")]
           public int parentId {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string user_name {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string password {get;set;}

           /// <summary>
           /// Desc:昵称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string nick_name {get;set;}

           /// <summary>
           /// Desc:真实姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string true_name {get;set;}

           /// <summary>
           /// Desc:手机号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mobile_phone_number {get;set;}

           /// <summary>
           /// Desc:电子邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string email {get;set;}

           /// <summary>
           /// Desc:性别：0，女;1，男
           /// Default:
           /// Nullable:True
           /// </summary>           
           public byte? sex {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime create_time {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime update_time {get;set;}

    }
}
