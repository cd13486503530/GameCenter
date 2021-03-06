﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using GameCenter.Core.Service;
using GameCenter.Core.Common;
using GameCenter.Core.Cache;
using GameCenter.Web.Manage.App_Start;

namespace GameCenter.Web.Manage.Controllers
{
    [Active("News")]
    public class NewsController : Controller
    {
        // GET: New
        public ActionResult Info(int id)
        {
            var info = NewsService.GetOneById(id);
            return View(info);
        }

        public ActionResult List(DtoNews dNews)
        {
            int total = 0;
            var list = NewsService.GetList(dNews, out total);
            ViewBag.PageHtml = PageHelper.ManagePager(total, dNews.PageIndex, dNews.PageSize);
            ViewBag.NewsForm = dNews ?? new DtoNews();
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddForm(DtoNews news)
        {
            string msg = string.Empty;
            HttpPostedFileBase file = Request.Files["Filedata"];
            var b = NewsService.AddNews(news, file, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Edit(int id)
        {
            var info = NewsService.GetOneById(id);
            return View(info);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditForm(DtoNews dNews)
        {
            string msg = string.Empty;
            var info = NewsService.GetOneById(dNews.Id);
            if (info.Id == 0)
            {
                return Json(new { status = false, msg = "参数错误" });
            }
            HttpPostedFileBase file = Request.Files["Filedata"];
            var b = NewsService.Update(dNews, file, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Delete(int id)
        {
            string msg = string.Empty;
            var b = NewsService.Delete(id, out msg);
            return Redirect(Request.UrlReferrer.ToString());
            //return Json(new { status = b, error = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}