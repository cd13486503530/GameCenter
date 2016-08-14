using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class DtoPrivatePage
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string ImagePath { get; set; }

        public string AndroidUrl { get; set; }

        public string IosUrl { get; set; }

        public string QQ { get; set; }

        public string Weixin { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
