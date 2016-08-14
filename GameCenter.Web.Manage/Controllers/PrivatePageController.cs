using GameCenter.Core.Common;
using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using GameCenter.Web.Manage.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    [Active("Private")]
    public class PrivateController : Controller
    { 
        // GET: Private 
        public ActionResult Info(int id)
        {
            var info = PrivatePageService.GetInfo(id);
            return View(info);
        }

        public ActionResult List(DtoPrivatePage dPrivatePage)
        {
            int total = 0;
            var list = PrivatePageService.GetList(dPrivatePage, out total);
            ViewBag.PageHtml = PageHelper.ManagePager(total, dPrivatePage.PageIndex, dPrivatePage.PageSize);
            ViewBag.PartnereForm = dPrivatePage ?? new DtoPrivatePage();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddForm(DtoPrivatePage dPrivatePage)
        {
            string msg = string.Empty;
            HttpPostedFileBase file = Request.Files["Filedata"];
            var b = PrivatePageService.AddForm(dPrivatePage, file, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Edit(int id)
        {
            var info = PrivatePageService.GetInfo(id);
            return View(info);
        }
        [HttpPost]
        public ActionResult EditForm(DtoPrivatePage dPrivatePage)
        {
            string msg = string.Empty;
            var info = PrivatePageService.GetInfo(dPrivatePage.Id);
            if (info.Id == 0)
            {
                return Json(new { status = false, error = "参数错误" });
            }
            HttpPostedFileBase file = Request.Files["Filedata"];
            var b = PrivatePageService.UpdatePrivatePage(dPrivatePage, file, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Delete(int id)
        {
            string msg = string.Empty;
            var b = PrivatePageService.Delete(id, out msg);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}