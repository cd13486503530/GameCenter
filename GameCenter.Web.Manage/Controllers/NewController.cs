using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using GameCenter.Core.Service;
using GameCenter.Core.Common;

namespace GameCenter.Web.Manage.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Info(int id)
        {
            var info = NewsService.GetOneById(id);
            return View(info);
        }

        public ActionResult List(DtoNews dNews)
        {
            var list = NewsService.GetList(dNews);
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddForm(DtoNews news)
        {
            string msg = string.Empty;
            var b = NewsService.AddNews(news, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Edit(int id)
        {
            var info = NewsService.GetOneById(id);
            return View(info);
        }
        [HttpPost]
        public ActionResult EditForm(DtoNews dNews)
        {
            string msg = string.Empty;
            var info = NewsService.GetOneById(dNews.Id);
            if (info.Id == 0)
            {
                return Json(new { status = false, msg = "参数错误" });
            }
            var b = NewsService.Update(info, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Delete(int id)
        {
            string msg = string.Empty;
            var b = NewsService.Delete(id, out msg);
            return Json(new { status = b, error = msg });
        }
    }
}