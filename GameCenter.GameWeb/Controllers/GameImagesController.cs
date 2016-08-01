using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core.Service;
using GameCenter.GameWeb.App_Start;
using GameCenter.Entity.Enum;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;

namespace GameCenter.GameWeb.Controllers
{
    public class GameImagesController : BaseController
    {
        // GET: GameImages
        public ActionResult Info(int type = 0)
        {
            if (type == 0)
                return View(new GameImages());

            ViewBag.Name = "游戏介绍";
            var image = GameImagesService.GetOneByTypeId(type, this.GameInfo.Id) ?? new GameImages();
            ViewBag.TypeName = ((GameImageType)type).ToString();
            return View(image);
        }

      
    }
}