using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
   public class MenuForm
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public int GameId { get; set; } 

        public bool IsMain { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int Sort { get; set; }

    }
}
