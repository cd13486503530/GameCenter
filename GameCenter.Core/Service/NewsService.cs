using GameCenter.Data;
using GameCenter.Entity.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Service
{
    public class NewsService
    {
        public static bool AddNews(News news)
        {
            int i = 0;
            using (var db = new PortalContext())
            {
                db.News.Add(news);
                i = db.SaveChanges();
            }
            if (i == 0)
            {
                return false;
            }
            return true;
        }

        public static News GetInfoById(int id)
        {
            var news = new News();
            using (var db = new PortalContext())
            {
                var info = db.News.First(a => a.Id == id);
                news = info ?? new News();
            }
            return news;
        }

        public static List<News> GetList(int indexPage, int pageSize, int type)
        {
            var list = new List<News>();
            using (var db = new PortalContext())
            {
                //var list = db.News.Take(20).Where(a => a.Status == 0).ToList();
                list = db.News.Skip((indexPage - 1) * pageSize).Take(pageSize).Where(a => a.NewsType == type).ToList();
            }
            return list;
        }


        public static bool Update(News news)
        {
            var i = 0;
            using (var db = new PortalContext())
            {
                var info = db.News.First(a => a.Id == news.Id);
                if (info == null)
                {
                    return false;
                }
                info.Title = news.Title;
                info.Contents = news.Contents;
                info.NewsType = news.NewsType;
                info.Tag = news.Tag;
                info.Author = news.Author;
                i = db.SaveChanges();
            }
            if (i == 0)
            {
                return false;
            }
            return true;
        }

        public static bool Delete(int id)
        {
            var i = 0;
            using (var db = new PortalContext())
            {
                var info = db.News.First(a => a.Id == id);
                if (info == null)
                {
                    return false;
                }
                info.Status = 1;
                i = db.SaveChanges();
            }
            if (i == 0)
            {
                return false;
            }
            return true;
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

        public static List<News> GetInfoByKey(string key)
        {
            var list = new List<News>();
            using (var db = new PortalContext())
            {
                list = db.News.Where(a => a.Title.Contains(key)).ToList();
            }
            return list;
        }
    }
}
