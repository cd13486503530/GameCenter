using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Entity.Dto
{
    public class DtoGame
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Code { get; set; }


        public string Desc { get; set; } 

        public string ImagePath { get; set; }

        public bool Disable { get; set; }

        public bool Top { get; set; }
    }
}
