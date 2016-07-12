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

        public int MenuId { get; set; }

        [MaxLength(128)]
        [Required, Column(TypeName = "varchar")]
        public string ImagePath { get; set; }

        public int Sort { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Info { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Url { get; set; }
    }
}
