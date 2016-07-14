using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCenter.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.Entity.Data;

namespace GameCenter.Test
{
    [TestClass()]
    public class NewsServiceTests
    {
        [TestMethod()]
        public void InfoTest()
        {
            int id = 2;
            NewsService.Info(id);
        }

        [TestMethod()]
        public void AddNewsTest()
        {
            News news = new News();
            news.Title = "标题";
            news.Contents = "这是内容内容";
            news.CreateTime = DateTime.Now;
            news.NewsType = 2;
            news.Tag = "这是一个标签";
            news.Author = "二爷";
            news.Status = 0;
            NewsService.AddNews(news);
        }

        [TestMethod()]
        public void ListTest()
        {

            NewsService.List();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            News news = new News();
            news.Id = 2;
            news.Title = "标题";
            news.Contents = "这是改变的内容内容";
            news.CreateTime = DateTime.Now;
            news.NewsType = 2;
            news.Tag = "这是一个标签";
            news.Author = "二爷";
            news.Status = 0;
            NewsService.Update(news);
        }
    }
}