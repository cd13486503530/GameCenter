using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using GameCenter.Entity.Enum;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.GameWeb.Controllers
{
    public class HeroController : BaseController
    {
        // GET: Hero
        public ActionResult List()
        {
            ViewBag.Name = "资料站";
            var recount = 0;
            var list = GameImagesService.GetPageList(new GameImagesForm()
            {
                GameId = GameInfo.Id,
                PageSize = 10000,
                Type = (int)GameImageType.英雄详情,
            }, out recount);

            return View(list);
        }

        public ActionResult Info(int id)
        {
            ViewBag.Name = "资料站";
            var info = GameImagesService.GetOneById(id) ?? new Entity.Data.GameImages();
            return View(info);
        }
    }
}