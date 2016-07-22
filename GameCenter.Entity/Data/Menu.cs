using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_Menu", Schema = "dbo")]
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32)]
        [Required, Column(TypeName = "varchar")]
        public string Name { get; set; }
   
        public int ParentId { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string Url { get; set; }

        public int GameId { get; set; }

        public int Sort { get; set; }

        public bool Disable { get; set; }
    }
}
