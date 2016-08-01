using AutoMapper;
using GameCenter.Core.Common;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GameCenter.Core.Service
{
    public class PartnerService
    {
        public static DtoPartner GetOneById(int id)
        {
            using (var db = new PortalContext())
            {
                var info = db.Partners.FirstOrDefault(a => a.Id == id);
                if (info == null)
                {
                    return new DtoPartner();
                }
                return Mapper.Map<DtoPartner>(info);
            }
        }

        public static List<DtoPartner> GetPartnerList(DtoPartner dPartner, out int total)
        {
            using (var db = new PortalContext())
            {
                var list = db.Partners.Where(a => a.Disable == false);
                if (!string.IsNullOrEmpty(dPartner.Name))
                    list = list.Where(a => a.Name.Contains(dPartner.Name));
                total = list.Count();
                list = list.OrderByDescending(a => a.Sort).Skip((dPartner.PageIndex - 1) * dPartner.PageSize).Take(dPartner.PageSize);
                return Mapper.Map<List<DtoPartner>>(list.ToList());
            }
        }
        public static List<DtoPartner> GetPartnerListBySotr()
        {
            using (var db = new PortalContext())
            {
                var list = db.Partners.Where(a => a.Disable == false).OrderByDescending(a => a.Sort).Take(20);
                return Mapper.Map<List<DtoPartner>>(list.ToList());
            }
        }
        public static bool AddPartner(DtoPartner dPartner, HttpPostedFileBase file, out string msg)
        {
            string tag = "Partner";
            msg = string.Empty;
            if (string.IsNullOrEmpty(dPartner.Name))
            {
                msg = "合作者名称不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(dPartner.LlinkUrl))
            {
                msg = "合作者链接不能为空";
                return false;
            }
            if (dPartner.Sort < 1 || dPartner.Sort > 100)
            {
                msg = "排名输入的格式不对";
                return false;
            }
            var imagePath = UploadFile.SaveImage(file, tag, 280, 95);
            if (string.IsNullOrEmpty(imagePath))
            {
                msg = "上传失败";
                return false;
            }
            using (var db = new PortalContext())
            {
                var p = Mapper.Map<Partner>(dPartner);
                p.ImagePath = imagePath;
                p.Disable = true;
                db.Partners.Add(p);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id, out string msg)
        {
            msg = string.Empty;
            using (var db = new PortalContext())
            {
                var info = db.Partners.First(a => a.Id == id);
                if (info == null)
                {
                    msg = "删除失败";
                    return false;
                }
                info.Disable = false;
                return db.SaveChanges() > 0;
            }
        }

        public static bool Update(DtoPartner dPartner, HttpPostedFileBase file, out string msg)
        {
            string tag = "Partner";
            msg = string.Empty;

            if (string.IsNullOrEmpty(dPartner.Name))
            {
                msg = "合作者名称不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(dPartner.LlinkUrl))
            {
                msg = "合作者链接不能为空";
                return false;
            }
            if (dPartner.Sort < 1 || dPartner.Sort > 100)
            {
                msg = "合作伙伴排名的格式不正确";
                return false;
            }
            if (file != null)
            {
                var imagePath = UploadFile.SaveImage(file, tag, 280, 95);
                if (string.IsNullOrEmpty(imagePath))
                {
                    msg = "上传失败";
                    return false;
                }
                dPartner.ImagePath = imagePath;
            }

            using (var db = new PortalContext())
            {
                var p = Mapper.Map<Partner>(dPartner);
                db.Set<Partner>().Attach(p);
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }


        }

        //public static List<DtoPartner> GetListByKey(string key)
        //{
        //    using (var db = new PortalContext())
        //    {
        //        Mapper.Initialize(cfg =>
        //        {
        //            cfg.CreateMap<Partner, DtoPartner>();
        //        });
        //        var list = db.Partners.Where(a => a.Name.Contains(key)).ToList();
        //        return Mapper.Map<List<DtoPartner>>(list);
        //    }
        //} 
    }
}

