using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_PrivatePage", Schema = "dbo")]
    public class PrivatePage
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string ImagePath { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string AndroidUrl { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string IosUrl { get; set; }

        [MaxLength(16)]
        [Column(TypeName = "varchar")]
        public string QQ { get; set; }

        [MaxLength(16)]
        [ Column(TypeName = "varchar")]
        public string Weixin { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "varchar")]
        public string CodeFirst { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "varchar")]
        public string CodeSecond { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar")]
        public string Keywords { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        public int Channel { get; set; }
    }
}
