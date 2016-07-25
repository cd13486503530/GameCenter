using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class DtoAdminUser
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 原始密码 
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassWord { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string ConfirmPassword { get; set; }

    }
}
