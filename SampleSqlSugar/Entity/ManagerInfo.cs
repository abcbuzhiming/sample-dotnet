using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SampleSqlSugar.Entity
{
    ///<summary>
    ///管理员信息
    ///</summary>
    [SugarTable("manager_info")]
    public partial class ManagerInfo
    {
           public ManagerInfo(){


           }
           /// <summary>
           /// Desc:创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="create_time")]
           public DateTime? createTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="device_state")]
           public int deviceState {get;set;}

           /// <summary>
           /// Desc:距离
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? distance {get;set;}

           /// <summary>
           /// Desc:id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="update_time")]
           public DateTime? updateTime {get;set;}

    }
}
