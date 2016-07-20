using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
   public class GameImagesForm
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public int GameId { get; set; }

        public string  Name { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
