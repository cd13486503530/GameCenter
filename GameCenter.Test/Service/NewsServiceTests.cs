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
            NewsService.GetInfoById(id);
        }

        [TestMethod()]
        public void AddNewsTest()
        {
            DtoNews news = new DtoNews();
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
        public void GetListTest()
        {

            //NewsService.GetList();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            DtoNews news = new DtoNews();
            news.Id = 2;
            news.Title = "标题";
            news.Contents = "这是改变的内容内容";
            news.CreateTime = DateTime.Now;
            news.NewsType = 2;
            news.Tag = "这是一个标签";
            news.Author = "二爷";
            news.Status = 0;
            //NewsService.Update(news);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int id = 1;
            NewsService.Delete(id);
        }

        [TestMethod()]
        public void GetInfoByKeyTest()
        {
            string key = "标";
            NewsService.GetInfoByKey(key);
        }
    }
}