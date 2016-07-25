using GameCenter.Core.Common;
using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using GameCenter.Web.Manage.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    [Active("Game")]
    public class GameImagesController : Controller
    {
        // GET: GameImages
        public ActionResult List(GameImagesForm req)
        {
            int total = 0;
            ViewBag.FormReq = req ?? new GameImagesForm();
            var list = GameImagesService.GetPageList(req, out total);
            ViewBag.Games = GameService.GetGamesCache();
            ViewBag.PageHtml = PageHelper.ManagePager(total, req.PageIndex, req.PageSize);
            return View(list);
        }

        public ActionResult Add(int type)
        {
            ViewBag.Type = type;
            ViewBag.Games = GameService.GetGamesCache();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddForm(DtoGameImages form)
        {
            var msg = string.Empty;
            var r = GameImagesService.Add(form,out msg);
            return Json(new { status = r,error = msg });
        }

        
        public ActionResult Edit(GameImagesForm req)
        {
            var info = GameImagesService.GetOneById(req.Id) ?? new GameImages();
            ViewBag.Form = req ?? new GameImagesForm();
            ViewBag.Games = GameService.GetGamesCache();
            return View(info);
        }

        public ActionResult Disable(int id)
        {
            var r = GameImagesService.Disable(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditForm(DtoGameImages form)
        {
            var msg = string.Empty;
            var info = GameImagesService.GetOneById(form.Id);
            if (info == null)
                return Json(new { status = false, msg = "参数错误" });
            
            var r = GameImagesService.Update(form, info ,out msg);
            return Json(new { status = r, error = msg });
        }

        public ActionResult HeroAdd(int type)
        {
            ViewBag.Type = type;
            ViewBag.Games = GameService.GetGamesCache();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult HeroAddForm(DtoGameImages form)
        {
            var msg = string.Empty;
            var r = GameImagesService.Add(form, out msg);
            return Json(new { status = r, error = msg });
        }

        public ActionResult HeroEdit(GameImagesForm req)
        {
            var info = GameImagesService.GetOneById(req.Id) ?? new GameImages();
            ViewBag.Form = req ?? new GameImagesForm();
            ViewBag.Games = GameService.GetGamesCache();
            return View(info);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult HeroEditForm(DtoGameImages form)
        {
            var msg = string.Empty;
            var info = GameImagesService.GetOneById(form.Id);
            if (info == null)
                return Json(new { status = false, msg = "参数错误" });

            var r = GameImagesService.Update(form, info, out msg);
            return Json(new { status = r, error = msg });
        }
    }
}