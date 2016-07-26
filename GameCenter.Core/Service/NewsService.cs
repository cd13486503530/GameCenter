using AutoMapper;
using GameCenter.Core.Common;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GameCenter.Core.Service
{
    public class NewsService
    {
        public static bool AddNews(DtoNews dNews, HttpPostedFileBase file, out string msg)
        {
            string tag = "News";
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
            var imagePath = UploadFile.SaveImage(file, tag, 280, 95);
            using (var db = new PortalContext())
            {
                News n = Mapper.Map<News>(dNews);
                n.ImagePath = imagePath;
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
                var info = db.News.First(a => a.Id == id);
                if (info == null)
                {
                    return new DtoNews();
                }
                return Mapper.Map<DtoNews>(info);
            }
        }

        public static List<DtoNews> GetList(DtoNews dNews, out int total)
        {
            using (var db = new PortalContext())
            {
                var list = db.News.Where(a => a.Status == 0);
                //total = list.Count;
                if (!string.IsNullOrEmpty(dNews.Title))
                    list = list.Where(a => a.Title.Contains(dNews.Title));

                if (dNews.NewsType > 0)
                    list = list.Where(a => a.NewsType == dNews.NewsType);
                total = list.Count();
                list = list.OrderByDescending(a => a.CreateTime).Skip((dNews.PageIndex - 1) * dNews.PageSize).Take(dNews.PageSize);
                var dList = Mapper.Map<List<DtoNews>>(list.ToList());
                foreach (var item in dList)
                {
                    var info = NewsTypeService.GetTypeCacheList().FirstOrDefault(a => a.Id == item.NewsType) ?? new DtoNewsType(); //NewsTypeService.GetNameById(item.NewsType);
                    item.NewsTypeName = info.Name;
                }
                return dList;
            }

        }

        public static List<DtoNews> GetHotListByGameId(int gameId,int top,bool imgNews)
        {
            using (var db = new PortalContext())
            {
                var list = db.News.Where(a=>a.Id > 0);
                if(gameId > 0)
                    list = list.Where(a => a.GameId == gameId);
                if (imgNews)
                    list = list.Where(a => !string.IsNullOrEmpty(a.ImagePath));
                list = list.OrderByDescending(a => a.Hot).OrderByDescending(a => a.CreateTime).Take(top);

                return Mapper.Map<List<DtoNews>>(list.ToList());
            }

        }

        public static bool Update(DtoNews dNews, HttpPostedFileBase file, out string msg)
        {
            string tag = "News";
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
            if (file != null)
            {
                var imagePath = UploadFile.SaveImage(file, tag, 280, 95);
                dNews.ImagePath = imagePath;
            }
            using (var db = new PortalContext())
            {
                try
                {
                    var n = Mapper.Map<News>(dNews);
                    db.Set<News>().Attach(n);
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
