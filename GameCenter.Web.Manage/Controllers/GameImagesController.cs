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
    }
}