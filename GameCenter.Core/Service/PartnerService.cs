﻿using AutoMapper;
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
                var info = db.Partners.First(a => a.Id == id);
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
                var list = db.Partners.Where(a => a.Disable == true);
                if (!string.IsNullOrEmpty(dPartner.Name))
                    list = list.Where(a => a.Name.Contains(dPartner.Name));
                total = list.Count();
                list = list.OrderByDescending(a => a.Sort).Skip((dPartner.PageIndex - 1) * dPartner.PageSize).Take(dPartner.PageSize);
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
            var imagePath = UploadFile.SaveFile(file, tag);
            if (imagePath == null)
            {
                msg = "上传失败";
                return false;
            }
            using (var db = new PortalContext())
            {
                var p = Mapper.Map<Partner>(dPartner);
                p.ImagePath = imagePath;
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
            if (string.IsNullOrEmpty(dPartner.ImagePath))
            {
                msg = "合作者LOGO不能为空";
                return false;
            }
            using (var db = new PortalContext())
            {
                var p = Mapper.Map<Partner>(dPartner);
                p.ImagePath = UploadFile.SaveFile(file, tag);
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

