using GameCenter.Data;
using GameCenter.Entity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Service
{
    public class NewsService
    {
        public static void AddNews(News news)
        {
            using (var db = new PortalContext())
            {
                db.News.Add(news);
                var a = db.SaveChanges();
            }
        }

        public static void Info(int id)
        {
            using (var db = new PortalContext())
            {
                var info = db.News.Where(a => a.Id == 2);
            }
        }

        public static void List()
        {
            using (var db = new PortalContext())
            {
                var list = db.News.Take(20).ToList();
            }
        }


        public static void Update(News news)
        {
            using (var db = new PortalContext())
            {
                var info = db.News.Where(a => a.Id == news.Id).First();
                info.Contents = news.Contents;
                db.SaveChanges();

            }
        }
    }
}
