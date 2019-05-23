using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SampleSqlSugar.Entity
{
    ///<summary>
    ///用户层级信息
    ///</summary>
    [SugarTable("user_tree")]
    public partial class UserTree
    {
           public UserTree(){


           }
           /// <summary>
           /// Desc:先祖id
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="ancestor_id")]
           public int ancestorId {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="create_time")]
           public DateTime? createTime {get;set;}

           /// <summary>
           /// Desc:后代id,即自己
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="descendant_id")]
           public int descendantId {get;set;}

           /// <summary>
           /// Desc:距离：子代到祖先中间隔了几级
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int distance {get;set;}

           /// <summary>
           /// Desc:id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="update_time")]
           public DateTime? updateTime {get;set;}

    }
}
