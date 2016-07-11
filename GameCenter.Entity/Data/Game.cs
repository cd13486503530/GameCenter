using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_Game", Schema = "dbo")]
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32)]
        [Required, Column(TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(32)]
        [Required, Column(TypeName = "varchar")]
        public string Code { get; set; }

        [MaxLength(2048)]
        [Column(TypeName = "varchar")]
        public string Desc { get; set; }


        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string ImagePath { get; set; }

        public bool Disable { get; set; }

        public bool Top { get; set; }




    }
}
