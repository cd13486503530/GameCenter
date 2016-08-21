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
    public class NewsTypeService
    {
        public static DtoNewsType GetNameById(int id)
        {
            using (var db = new PortalContext())
            {
                var info = db.NewsTypes.FirstOrDefault(a => a.Id == id) ?? new NewsType();
                return Mapper.Map<DtoNewsType>(info);
            }
        }
        public static List<DtoNewsType> GetTypeList()
        {
            using (var db = new PortalContext())
            {
                var list = db.NewsTypes.ToList();
                return Mapper.Map<List<DtoNewsType>>(list);
            }
        }

        public static DtoNewsType GetOneByName(string name)
        {
            return GetTypeCacheList().FirstOrDefault(a => a.Name == name) ?? new DtoNewsType();
        }

        public static List<DtoNewsType> GetTypeCacheList()
        {
            //TimeSpan ts = new TimeSpan(1, 0, 0, 0, 0);
            var key = "GameCenter.Core.Service.NewsTypeService.GetNewsTypeCache";
            var getCache = LocalCache.Instance().Get<List<DtoNewsType>>(key);
            if (getCache == null)
            {
                var newsType = GetTypeList();
                LocalCache.Instance().Set(key, newsType, DateTime.Now.AddDays(1));
                return newsType;
            }
            return getCache;
        }
    }
}
