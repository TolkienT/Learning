using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model.Entities
{
    public class BaseInfo
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新用户
        /// </summary>
        public string UpdateUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 删除用户
        /// </summary>
        public string DeleteUser { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
