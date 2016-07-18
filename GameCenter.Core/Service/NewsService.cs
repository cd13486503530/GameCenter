using AutoMapper;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GameCenter.Core.Service
{
    public class NewsService
    {
        public static bool AddNews(DtoNews dNews, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(dNews.Title))
            {
                msg = "新闻标题不能空";
                return false;
            }
            if (string.IsNullOrEmpty(dNews.Contents))
            {
                msg = "新闻内容不能为空";
                return false;
            }
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<DtoNews, News>();
                });
                News n = Mapper.Map<News>(dNews);
                n.CreateTime = DateTime.Now;
                n.Status = 0;
                db.News.Add(n);
                return db.SaveChanges() > 0;
            }

        }

        public static DtoNews GetOneById(int id)
        {
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<News, DtoNews>();
                });
                var info = db.News.First(a => a.Id == id);
                if (info == null)
                {
                    return new DtoNews();
                }
                return Mapper.Map<DtoNews>(info);
            }
        }

        public static List<DtoNews> GetList(DtoNews dNews)
        {
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<News, DtoNews>();
                });
                var list = db.News.Skip((dNews.PageIndex - 1) * dNews.PageSize).Take(dNews.PageSize).Where(a => a.NewsType == dNews.NewsType && a.Status == 0).OrderByDescending(a => a.CreateTime).ToList();
                return Mapper.Map<List<DtoNews>>(list);
            }

        }


        public static bool Update(DtoNews dNews, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(dNews.Title))
            {
                msg = "新闻标题不能空";
                return false;
            }
            if (string.IsNullOrEmpty(dNews.Contents))
            {
                msg = "新闻内容不能为空";
                return false;
            }
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<DtoNews, News>();
                });
                Mapper.Map<News>(dNews);
                return db.SaveChanges() > 0;
            }
        }

        public static bool Delete(int id, out string msg)
        {
            msg = string.Empty;
            using (var db = new PortalContext())
            {
                var info = db.News.First(a => a.Id == id);
                if (info == null)
                {
                    msg = "删除失败";
                    return false;
                }
                info.Status = 1;
                return db.SaveChanges() > 0;
            }

        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="key"></param>
        //public static void GetInfoByKey(string key)
        //{
        //    using (var db = new PortalContext())
        //    {
        //        var list = db.News.Where(a => SqlFunctions.PatIndex(key + "%", a.Title) > 0);
        //    }
        //}

        public static List<DtoNews> GetInfoByKey(string key)
        {
            using (var db = new PortalContext())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<News, DtoNews>();
                });
                var list = db.News.Where(a => a.Title.Contains(key)).ToList();
                if (list == null)
                {
                    return new List<DtoNews>();
                }
                return Mapper.Map<List<DtoNews>>(list);
            }
        }

        public static int ContainsNewName(string Title)
        {
            using (var db = new PortalContext())
            {
                return db.News.Count(a => a.Title == Title);
            }
        }
    }
}
