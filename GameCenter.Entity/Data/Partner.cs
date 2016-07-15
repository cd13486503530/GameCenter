using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_Partner", Schema = "dbo")]
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        [Required, Column(TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(128)]
        [Required, Column(TypeName = "varchar")]
        public string LlinkUrl { get; set; }

        [MaxLength(256)]
        [Required, Column(TypeName = "varchar")]
        public string ImagePath { get; set; }

        public int Status { get; set; }
    }
}
