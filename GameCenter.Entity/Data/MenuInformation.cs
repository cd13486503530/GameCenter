using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_MenuInformation", Schema = "dbo")]
   public class MenuInformation
    {
        [Key]
        public int Id { get; set; }
        public int MenuId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength]
        public string GameDescription { get; set; }
        
        public bool Disable { get; set; }
    }
}
