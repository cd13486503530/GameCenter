using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class DtoNews
    {
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 新闻类型
        /// </summary>
        public int NewsType { get; set; }
        /// <summary>
        /// 新闻名称
        /// </summary>
        public string NewsTypeName { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string Author { get; set; }

        public DateTime CreateTime { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;


    }
}
