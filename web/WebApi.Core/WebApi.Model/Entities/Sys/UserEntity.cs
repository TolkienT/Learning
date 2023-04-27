using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Enums;

namespace WebApi.Model.Entities.Sys
{
    [SugarTable("sys_user")]
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// 名字
        /// </summary>
        [SugarColumn(ColumnName = "first_name")]
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// 姓氏
        /// </summary>

        [SugarColumn(ColumnName = "last_name")]
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "full_name")]
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "nick_name")]
        public string NickName { get; set; } = string.Empty;
        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "gender")]
        public Gender Gender { get; set; } = Gender.Unknow;
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnName = "user_name")]
        public string UserName { get; set; } = string.Empty;

    }
}
