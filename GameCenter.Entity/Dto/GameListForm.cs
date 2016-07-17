using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class GameListForm
    {

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string Code { get; set; }

        public string Name { get; set; }

        public bool? Disable { get; set; }

        public bool? Top { get; set; }
    }
}
