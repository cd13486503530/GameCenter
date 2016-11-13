using AutoMapper;
using GameCenter.Core.Common;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GameCenter.Core.Service
{
    public class PrivatePageService
    {
        public static List<DtoPrivatePage> GetList(DtoPrivatePage dPrivatePage, out int total)
        {
            using (var db = new PortalContext())
            {
                var list = db.PrivatePages.OrderBy(a => a.Id).Skip((dPrivatePage.PageIndex - 1) * dPrivatePage.PageSize).Take(dPrivatePage.PageSize).ToList();
                total = list.Count();
                return Mapper.Map<List<DtoPrivatePage>>(list);

            }
        }


        public static DtoPrivatePage GetInfo(int id)
        {
            using (var db = new PortalContext())
            {
                var info = db.PrivatePages.FirstOrDefault(a => a.Id == id);
                if (info == null)
                {
                    return new DtoPrivatePage();
                }
                return Mapper.Map<DtoPrivatePage>(info);
            }
        }

        public static DtoPrivatePage GetInfoByGameId(int gameId)
        {
            using (var db = new PortalContext())
            {
                var info = db.PrivatePages.FirstOrDefault(a => a.GameId == gameId);
                if (info == null)
                {
                    return new DtoPrivatePage();
                }
                return Mapper.Map<DtoPrivatePage>(info);
            }
        }

        public static DtoPrivatePage GetInfoByGameId(int gameId, int channelId)
        {
            using (var db = new PortalContext())
            {
                var info = db.PrivatePages.FirstOrDefault(a => a.GameId == gameId && a.Channel == channelId);
                if (info == null)
                {
                    return new DtoPrivatePage();
                }
                return Mapper.Map<DtoPrivatePage>(info);
            }
        }

        public static bool AddForm(DtoPrivatePage dPrivatePage, HttpPostedFileBase file, out string msg)
        {
            string tag = "Private";
            msg = string.Empty;
            var imagePath = string.Empty;
            if (file != null)
            {
                imagePath = UploadFile.SaveFile(file, tag);
                if (string.IsNullOrEmpty(imagePath))
                {
                    msg = "上传失败";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(dPrivatePage.QQ))
            {
                msg = "官方QQ不能空";
                return false;
            }
            if (string.IsNullOrEmpty(dPrivatePage.Weixin))
            {
                msg = "官方微信不能空";
                return false;
            }
            using (var db = new PortalContext())
            {
                try
                {
                    var pp = Mapper.Map<PrivatePage>(dPrivatePage);
                    pp.ImagePath = imagePath;
                    db.PrivatePages.Add(pp);
                    return db.SaveChanges() > 0;
                }
                catch (DbEntityValidationException ex)
                {
                    msg = ex.ToString();
                    return false;
                }
            }
        }

        public static bool UpdatePrivatePage(DtoPrivatePage dPrivatePage, HttpPostedFileBase file, out string msg)
        {
            string tag = "Private";
            msg = string.Empty;
            
            if (file != null)
            {
                var imagePath = UploadFile.SaveFile(file, tag);
                if (string.IsNullOrEmpty(imagePath))
                {
                    msg = "上传失败";
                    return false;
                }
                dPrivatePage.ImagePath = imagePath;
            }
            if (string.IsNullOrEmpty(dPrivatePage.QQ))
            {
                msg = "官方QQ不能空";
                return false;
            }
            if (string.IsNullOrEmpty(dPrivatePage.Weixin))
            {
                msg = "官方微信不能空";
                return false;
            }
            using (var db = new PortalContext())
            {
                var pp = Mapper.Map<PrivatePage>(dPrivatePage);
                db.Set<PrivatePage>().Attach(pp);
                db.Entry(pp).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id, out string msg)
        {
            msg = string.Empty;
            using (var db = new PortalContext())
            {
                var info = db.PrivatePages.First(a => a.Id == id);
                if (info == null)
                {
                    msg = "删除失败";
                    return false;
                }
                //info.Disable = false;
                return db.SaveChanges() > 0;
            }
        }
    }
}
