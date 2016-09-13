using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Service
{
    public class SeoService
    {
        public static SeoInfo GetInfo(int gameId, int menuId)
        {
            using (var db = new PortalContext())
            {
                var info = db.Seos.FirstOrDefault(a => a.GameId == gameId && a.MenuId == menuId) ?? new SeoInfo();

                return info;
            }
        }
    }
}
