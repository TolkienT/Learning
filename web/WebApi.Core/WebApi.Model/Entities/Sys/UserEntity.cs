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
    public class UserEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public long Id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [SugarColumn(ColumnName = "first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>

        [SugarColumn(ColumnName = "last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "full_name")]
        public string FullName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "nick_name")]
        public string NickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "gender")]
        public Gender Gender { get; set; } = Gender.Unknow;
        /// <summary>
        /// 用户账号
        /// </summary>
        [SugarColumn(ColumnName = "account")]
        public string Account { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
    }
}
