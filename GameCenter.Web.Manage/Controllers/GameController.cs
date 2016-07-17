using GameCenter.Core.Common;
using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using GameCenter.Web.Manage.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    public class GameController : BaseController
    {
        // GET: Game
        public ActionResult List(GameListForm req)
        {
            int total = 0;
            var list = GameService.GetPageList(req, out total);
            ViewBag.PageHtml = PageHelper.ManagePager(total, req.PageIndex, req.PageSize);
            ViewBag.FormReq = req ?? new GameListForm();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddForm(GameForm req)
        {
            var error = string.Empty;
            HttpPostedFileBase file = Request.Files["Filedata"];
            var r = GameService.Add(req, file, out error);
            return Json(new { status = r, msg = error });
        }

        public ActionResult Edit(int id)
        {
            var info = GameService.GetGameOne(id) ?? new Game();
            return View(info);
        }

        public ActionResult EditForm(GameEditForm req)
        {
            var error = string.Empty;
            HttpPostedFileBase file = Request.Files["Filedata"];
            var sourceInfo = GameService.GetGameOne(req.Id);
            if(sourceInfo == null)
                return Json(new { status = false, msg = "参数错误" });

            var r = GameService.Edit(req, sourceInfo, file, out error);
            return Json(new { status = r, msg = error });
             
        }
    }
}