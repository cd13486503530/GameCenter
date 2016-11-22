using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Data
{
    [Table("t_GameInfo", Schema = "dbo")]
    public class GameInfo
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string Logo { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string Icon { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string QrCodeImage { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string IosDl { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string AndriodDl { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImage0 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImage1 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImage2 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImage3 { get; set; }     

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImage0 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImage1 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImage2 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImage3 { get; set; }

        [MaxLength(64)]
        [Column(TypeName = "varchar")]
        public string Version { get; set; }

        [MaxLength(64)]
        [Column(TypeName = "varchar")]
        public string FileName { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string VedioImage { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar")]
        public string VedioUrl { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImageUrl0 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImageUrl1 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImageUrl2 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string BgImageUrl3 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImageUrl0 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImageUrl1 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImageUrl2 { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string FocusImageUrl3 { get; set; }
    }
}
