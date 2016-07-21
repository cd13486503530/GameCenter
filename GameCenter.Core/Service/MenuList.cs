using AutoMapper;
using GameCenter.Core.Cache;
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
    public class MenuList
    {
        private static string key = "GameCenter.Core.Service.GetListCache";
        public static List<DtoMenu> GetList(MenuForm Form)
        {
            var cache  = LocalCache.Instance().Get<List<DtoMenu>>(key);
            if(cache != null)
            {
                return cache;
            }
            using (var db = new PortalContext())
            {
                var list = Mapper.Map<List<DtoMenu>>(db.Menus.Take(100).ToList());
                LocalCache.Instance().Set(key,list,DateTime.Now.Add(3).TimeOfDay);
                return list;
            }
        }

        public static bool Add(MenuForm form,out string msg)
        {
            msg = string.Empty;
            if(!Cheack(form,out msg))
            {
                return false;
            }

            using (var db = new PortalContext())
            {
                var info = Mapper.Map<Menu>(form);
                db.Menus.Add(info);
                var r = db.SaveChanges() > 0;
                if (r)
                    LocalCache.Instance().Remove(key);
                return r;
            }
        }
        public static bool Edit(MenuForm form, out string msg)
        {
            msg = string.Empty;
            if (!Cheack(form, out msg))
            {
                return false;
            }

            using (var db = new PortalContext())
            {
                var info = Mapper.Map<Menu>(form);
                db.Set<Menu>().Attach(info);
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                var r = db.SaveChanges() > 0;
                if (r)
                    LocalCache.Instance().Remove(key);
                return r;
            }
        }


        private static bool Cheack(MenuForm form ,out string msg)
        {
            msg = string.Empty;
            if(form.GameId < 1)
            {
                msg = "请选择要添加的游戏";
                return false;
            }

            if(form.ParentId < 1)
            {
                msg = "请选择上级菜单";
                return false;
            }

            return true;
        }
    }
}
