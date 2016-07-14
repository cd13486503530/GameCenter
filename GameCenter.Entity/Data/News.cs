using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_News", Schema = "dbo")]
    public class News
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        [Required, Column(TypeName = "varchar")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Contents { get; set; }

        public DateTime CreateTime { get; set; }

        public int NewsType { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [MaxLength(64)]
        [Column(TypeName = "varchar")]
        public string Tag { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [MaxLength(64)]
        [Column(TypeName = "varchar")]
        public string Author { get; set; }

        /// <summary>
        /// 删除状态，0是未删除，1是删除
        /// </summary>
        public int Status { get; set; }
    }
}
