using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_GameImages", Schema = "dbo")]
    public class GameImages
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }

        public string Name { get; set; }

        [MaxLength(128)]
        [Required, Column(TypeName = "varchar")]
        public string ImagePath { get; set; }

        /// <summary>
        /// 暂时只用于英雄介绍的头像图片
        /// </summary>
        public string SmallImagePath { get; set; }
        [MaxLength(128)]
        [Column(TypeName = "varchar")]

        public int Sort { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Info { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Url { get; set; }

        /// <summary>
        /// 游戏图片类型，GameImageType指定
        /// </summary>
        public int Type { get; set; }

        public bool Disable { get; set; }
    }
}
