using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_NewsType", Schema = "dbo")]
    public class NewsType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32)]
        [Required, Column(TypeName = "varchar")]
        public string Name { get; set; }
    }
}
