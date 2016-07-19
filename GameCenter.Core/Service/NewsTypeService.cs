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
        public static List<DtoNewsType> GetTypeList()
        {
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<NewsType, DtoNewsType>();
                });
                var list = db.NewsTypes.ToList();
                return Mapper.Map<List<DtoNewsType>>(list);
            }
        }

        public static List<DtoNewsType> GetTypeCacheList()
        {
            //TimeSpan ts = new TimeSpan(1, 0, 0, 0, 0);
            var key = "GameCenter.Core.Service.NewsTypeService.GetNewsTypeCache";
            var getCache = LocalCache.Instance().Get<List<DtoNewsType>>(key);
            if (getCache == null)
            {
                var newsType = GetTypeList();
                LocalCache.Instance().Set(key, newsType, DateTime.Now.AddDays(1).TimeOfDay);
                return newsType;
            }
            return getCache;
        }
    }
}
