using GameCenter.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Service
{
    public class GameImagesService
    {
        public static List<DtoGameImages> GetPageList(GameImagesForm form, out int recount)
        {
            recount = 0;
            using (var db = new PortalContext())
            {
                return AutoMapper.Mapper.Map<List<DtoGameImages>>(db.GameImages.Take(10));
            }
        }
    }
}
