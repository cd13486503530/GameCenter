using AutoMapper;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Service
{
    public class ChannelService
    {
        public static bool Add(DtoChannel channel,  out string msg)
        { 
            msg = string.Empty;
            if (string.IsNullOrEmpty(channel.Name))
            {
                msg = "频道名称不能空";
                return false;
            }
             
            using (var db = new PortalContext())
            {
                Channel n = Mapper.Map<Channel>(channel);
                n.Name = channel.Name;
                n.Status = 0;
                db.Channels.Add(n);
                return db.SaveChanges() > 0;
            }

        }

        public static DtoChannel GetOneById(int id)
        {
            using (var db = new PortalContext())
            {
                var info = db.Channels.FirstOrDefault(a => a.Id == id);
                if (info == null)
                {
                    return new DtoChannel();
                }
                return Mapper.Map<DtoChannel>(info);
            }
        }

        public static List<DtoChannel> GetListALL()
        {
            using (var db = new PortalContext())
            {
                var list = db.Channels.Where(a => a.Status == 0);  
                var dList = Mapper.Map<List<DtoChannel>>(list.ToList()); 
                return dList;
            }

        }
        public static bool Update(DtoChannel channel, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(channel.Name))
            {
                msg = "频道名称不能空";
                return false;
            }
         
            using (var db = new PortalContext())
            {
                try
                {
                    var n = Mapper.Map<Channel>(channel);
                    db.Set<Channel>().Attach(n);
                    db.Entry(n).State = System.Data.Entity.EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbEntityValidationException ex)
                {
                    return false;
                } 
            }
        }

        public static bool Delete(int id, out string msg)
        {
            msg = string.Empty;
            using (var db = new PortalContext())
            {
                var info = db.Channels.First(a => a.Id == id);
                if (info == null)
                {
                    msg = "删除失败";
                    return false;
                }
                info.Status = 1;
                return db.SaveChanges() > 0;
            }

        }
    }
}
