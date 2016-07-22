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
    public class MenuService
    {
        private static string key = "GameCenter.Core.Service.GetListCache";
        public static List<DtoMenu> GetList(MenuForm req)
        {
            using (var db = new PortalContext())
            {
                var query = db.Menus.Where(a => a.ParentId == req.ParentId);
                if (req.IsMain)
                    query = query.Where(a => a.GameId == 0);
                else if (req.GameId > 0)
                    query = query.Where(a => a.GameId == req.GameId);
                else
                    query = query.Where(a => a.GameId > 0);

                return Mapper.Map<List<DtoMenu>>(query.Take(100).ToList());
            }
        }

        public static List<DtoMenu> GetListCache()
        {
            var cache = LocalCache.Instance().Get<List<DtoMenu>>(key);
            if (cache != null)
            {
                return cache;
            }

            using (var db = new PortalContext())
            {
                var list = Mapper.Map<List<DtoMenu>>(db.Menus.Take(1000).ToList());
                LocalCache.Instance().Set(key, list, DateTime.Now.AddDays(3).TimeOfDay);
                return list;
            }
        }

        public static DtoMenu GetOne(int id)
        {
            using (var db = new PortalContext())
            {
                var info = db.Menus.FirstOrDefault(a => a.Id == id);
                return Mapper.Map<DtoMenu>(info);
            }
        }

        public static bool Add(MenuForm form, out string msg)
        {
            msg = string.Empty;
            if (!Cheack(form, out msg))
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


        private static bool Cheack(MenuForm form, out string msg)
        {
            msg = string.Empty;

            if (string.IsNullOrEmpty(form.Name))
            {
                msg = "请输入菜单名称";
                return false;
            }

            if (string.IsNullOrEmpty(form.Url))
            {
                msg = "请输入菜单链接";
                return false;
            }

            //if (form.GameId < 1)
            //{
            //    msg = "请选择要添加的游戏";
            //    return false;
            //}

            //if (form.ParentId < 1)
            //{
            //    msg = "请选择上级菜单";
            //    return false;
            //}

            return true;
        }


        public static bool Disable(DtoMenu dtoMenu)
        {
            using (var db = new PortalContext())
            {  
                var info = Mapper.Map<Menu>(dtoMenu);
                db.Set<Menu>().Attach(info);
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        } 

        
    }
}
