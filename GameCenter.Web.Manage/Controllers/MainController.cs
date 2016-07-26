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
    [Active("Main")]
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Set()
        {
            var info = GameInfoService.GetGameInfo(0) ?? new GameInfo();
            var game = GameService.GetGamesCache().FirstOrDefault(a => a.Id == 0) ?? new DtoGame();
            ViewBag.GameInfo = game;
            return View(info);
        }

        [HttpPost]
        public ActionResult Post(GameInfoForm req)
        {
            string msg = string.Empty;
            var result = false;
            var gameInfo = GameInfoService.GetGameInfo(req.GameId);

            if (gameInfo == null)
                result = GameInfoService.Add(req, out msg,false);
            else
                result = GameInfoService.Update(req, gameInfo, out msg,false);
            return Json(new { status = result, msg = msg });
        }


    }
}