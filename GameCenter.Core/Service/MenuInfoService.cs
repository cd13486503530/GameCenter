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
    public class MenuInfoService
    {
        public static bool Add(MenuInformation req)
        {
            using (var db = new PortalContext())
            {
                db.MenuInformations.Add(req);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Edit(MenuInformation req)
        {
            using (var db = new PortalContext())
            {
                db.Set<MenuInformation>().Attach(req);
                db.Entry(req).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static MenuInformation GetOne(int menuId)
        {
            using (var db = new PortalContext())
            {
                return db.MenuInformations.FirstOrDefault(a => a.MenuId == menuId);
            }
        }
    }
}
