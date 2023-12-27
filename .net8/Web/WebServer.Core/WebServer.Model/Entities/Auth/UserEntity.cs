using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model.Enums;

namespace WebServer.Model.Entities.Auth
{
    [SugarTable("user")]
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnName = "user_id")]
        public string UserId { get; set; } = string.Empty;
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
        [SugarColumn(ColumnName = "user_name")]
        public string UserName { get; set; } = string.Empty;
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
        /// 密码
        /// </summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }


    }
}
