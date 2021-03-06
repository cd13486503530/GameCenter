﻿using AutoMapper;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
            if (form.PageIndex < 1)
                form.PageIndex = 1;

            using (var db = new PortalContext())
            {
                var list = db.GameImages.Where(a => a.Disable == false);
                if (!string.IsNullOrEmpty(form.Name))
                    list = list.Where(a => SqlFunctions.PatIndex(form.Name + "%", a.Name) > 0);

                if (form.Type > 0)
                    list = list.Where(a => a.Type == form.Type);

                if (form.GameId > 0)
                    list = list.Where(a => a.GameId == form.GameId);
                recount = list.Count();
                list = list.OrderBy(a => a.Sort).Skip((form.PageIndex - 1) * form.PageSize).Take(form.PageSize);
                return Mapper.Map<List<DtoGameImages>>(list.ToList());
            }
        }

        public static bool Add(DtoGameImages form, out string msg)
        {
            msg = string.Empty;

            if (!Check(form, out msg))
                return false;

            using (var db = new PortalContext())
            {
                var info = Mapper.Map<GameImages>(form);
                db.GameImages.Add(info);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(DtoGameImages form,GameImages source , out string msg)
        {
            msg = string.Empty;

            if (!Check(form, out msg))
                return false;

            using (var db = new PortalContext())
            {
                var gameImages = Mapper.Map<GameImages>(form);
                db.Set<GameImages>().Attach(gameImages);
                db.Entry(gameImages).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        private static bool Check(DtoGameImages form, out string msg)
        {
            msg = string.Empty;
            //if (string.IsNullOrEmpty(form.ImagePath))
            //{
            //    msg = "请上传图片";
            //    return false;
            //}

            if (form.Type < 1)
            {
                msg = "请选择类型";
                return false;
            }
            return true;
        }

        public static GameImages GetOneById(int id)
        {
            using (var db = new PortalContext())
            {
                return db.GameImages.FirstOrDefault(a=>a.Id == id);
            }
        }
        public static GameImages GetOneByTypeId(int typeId,int gameId)
        {
            using (var db = new PortalContext())
            {
                return db.GameImages.FirstOrDefault(a=>a.Type == typeId && a.GameId == gameId && !a.Disable);
            }
        }

        public static bool Disable(int id)
        {
            using (var db = new PortalContext())
            {
                var info = GameImagesService.GetOneById(id);
                info.Disable = true;
                db.Set<GameImages>().Attach(info);
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
