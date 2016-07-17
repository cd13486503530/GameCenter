using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_AdminUser", Schema = "dbo")]
    public class AdminUser
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(32)]
        [Required, Column(TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string NiceName { get; set; }

        [MaxLength(32)]
        [Required, Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [MaxLength(32)]
        [Required, Column(TypeName = "varchar")]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public int Desable { get; set; } 

    }
}
