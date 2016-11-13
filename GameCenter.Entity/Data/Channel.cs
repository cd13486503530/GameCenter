using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_Channel", Schema = "dbo")]
    public class Channel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        public int Status { get; set; }
    }
}
