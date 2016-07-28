using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core.Service;
using GameCenter.Entity.Dto;

namespace GameCenter.Web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            ViewBag.Name = "新闻中心";
            ViewBag.Type1 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("综合").Id, 20); // 综合
            ViewBag.Type2 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("新闻").Id, 20); // 新闻
            ViewBag.Type3 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("公告").Id, 20); // 公告
            ViewBag.Type4 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("活动").Id, 20); // 活动
            return View();
        }

        public ActionResult Info(int id = 0)
        {
            ViewBag.Name = "新闻中心";
            var newsInfo = NewsService.GetOneById(id);
            return View(newsInfo);
        }
    }
}