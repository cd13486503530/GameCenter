using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using GameCenter.Core.Service;

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

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditForm(int id)
        {
            string msg = string.Empty;
            var info = NewsService.GetOneById(id);
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