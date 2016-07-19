using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.Web.Manage.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    [Active("Game")]
    public class GameInfoController : Controller
    {
        // GET: GameInfo
        public ActionResult Index(int gameId = 0)
        {
            var info = GameInfoService.GetGameInfo(gameId) ?? new GameInfo();
            return View(info);
        }

        [HttpPost]
        public ActionResult EditInfo()
        {
            return Json("");
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            return View();
        }
    }
}