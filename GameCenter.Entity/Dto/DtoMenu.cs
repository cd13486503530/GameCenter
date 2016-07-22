using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class DtoMenu
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string GameName { get; set; }

        public int ParentId { get; set; }

        public string Url { get; set; }

        public int GameId { get; set; }

        public int Sort { get; set; }

        public bool Disable { get; set; }


    }
}
