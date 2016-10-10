using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class DtoGameInfo
    {

        public int Id { get; set; }

        public int GameId { get; set; }

        public string Logo { get; set; }

        public string QrCodeImage { get; set; }

        public string IosDl { get; set; }

        public string AndriodDl { get; set; } 

        public string BgImage0 { get; set; }

        public string BgImage1 { get; set; }

        public string BgImage2 { get; set; }

        public string BgImage3 { get; set; }

        public string FocusImage0 { get; set; }

        public string FocusImage1 { get; set; }

        public string FocusImage2 { get; set; }

        public string FocusImage3 { get; set; }
    }
}
