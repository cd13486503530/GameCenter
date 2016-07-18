using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCenter.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;

namespace GameCenter.Test
{
    [TestClass()]
    public class NewsServiceTests
    {
        [TestMethod()]
        public void GetInfoByIdTest()
        {
            int id = 2;
            NewsService.GetOneById(id);
        }

        [TestMethod()]
        public void AddNewsTest()
        {
            string msg = string.Empty;
            DtoNews news = new DtoNews();
            news.Title = "标题";
            news.Contents = "这是内容内容";
            news.NewsType = 2;
            news.Tag = "这是一个标签";
            news.Author = "二爷";
            NewsService.AddNews(news, out msg);
        }

        [TestMethod()]
        public void GetListTest()
        {

            //NewsService.GetList();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            DtoNews news = new DtoNews();
            news.Title = "标题";
            news.Contents = "这是改变的内容内容";
            news.NewsType = 2;
            news.Tag = "这是一个标签";
            news.Author = "二爷";
            //NewsService.Update(news);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            string msg = string.Empty;
            int id = 1;
            NewsService.Delete(id, out msg);
        }

        [TestMethod()]
        public void GetInfoByKeyTest()
        {
            string key = "标";
            NewsService.GetInfoByKey(key);
        }
    }
}