using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class DtoGameImages
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string GameName { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string SmallImagePath { get; set; }

        public int Sort { get; set; }

        public string Info { get; set; }

        public string Url { get; set; }

        public int Type { get; set; }

        public string TypeName { get; set; }
    }
}
