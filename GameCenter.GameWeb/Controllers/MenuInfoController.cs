using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.GameWeb.Controllers
{
    public class MenuInfoController : BaseController
    {
        
        public ActionResult Info(int MenuId)
        {
            var gameInfo = GameInfoService.GetGameInfo(GameInfo.Id) ?? new GameInfo();
            ViewBag.Logo = GameCenter.Core.Common.Domain.GetImage(gameInfo.Logo);// /Content/img/ling-logo.png
            var info = MenuInfoService.GetOne(MenuId) ?? new MenuInformation();

            return View(info);
        }
    }
}