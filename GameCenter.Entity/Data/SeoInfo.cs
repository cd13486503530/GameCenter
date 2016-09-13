using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_Seo", Schema = "dbo")]
    public class SeoInfo
    {
        [Key]
        public int Id { get; set; }
        public int GameId { get; set; }
        public int MenuId { get; set; }
        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }
        [MaxLength(512)]
        [Column(TypeName = "varchar")]
        public string Keywords { get; set; }
        [MaxLength(2048)]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }
    }
}
