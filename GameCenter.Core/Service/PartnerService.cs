using AutoMapper;
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
    public class PartnerService
    {
        public static DtoPartner GetOneById(int id)
        {
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Partner, DtoPartner>();
                });
                var info = db.Partners.First(a => a.Id == id);
                if (info == null)
                {
                    return new DtoPartner();
                }
                return Mapper.Map<DtoPartner>(info);
            }
        }

        public static List<DtoPartner> GetPartnerList(int pageIndex, int pageSize)
        {
            var dList = new List<DtoPartner>();
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Partner, DtoPartner>();
                });
                var list = db.Partners.Skip((pageIndex - 1) * pageSize).Take(pageSize).Where(a => a.Disable == true).ToList();
                return Mapper.Map<List<DtoPartner>>(list);
            }
        }

        public static bool AddPartner(DtoPartner dPartner, out string msg)
        {
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
                msg = "合作者标志不能为空";
                return false;
            }
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<DtoPartner, Partner>();
                });
                var p = Mapper.Map<Partner>(dPartner);
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

        public static bool Update(DtoPartner dPartner,out string msg)
        {
            msg = string.Empty;
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<DtoPartner, Partner>();
                });
                Mapper.Map<Partner>(dPartner);
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

