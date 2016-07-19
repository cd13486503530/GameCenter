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
    public class GameInfoController : Controller
    {
        // GET: GameInfo
        public ActionResult Index(int gameId = 0)
        {
            var info = GameInfoService.GetGameInfo(gameId) ?? new GameInfo();
            ViewBag.GameId = gameId;
            return View(info);
        }

        [HttpPost]
        public ActionResult EditInfo(GameInfoForm req)
        {
            string msg = string.Empty;
            var result = false;
            var gameInfo = GameInfoService.GetGameInfo(req.GameId);
           
            if (gameInfo == null)
                result = GameInfoService.Add(req, out msg);
            else
                result = GameInfoService.Update(req, gameInfo, out msg);
            return Json(new { status = result, msg = msg });
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var fileName = string.Empty;
            var file = Request.Files[0];
            var fileInputName = Request.Files.AllKeys[0];
            int width = 0, heigth = 0;
            var name = file.FileName;
            if (fileInputName.Contains("BgImage"))
            {
                //具体参数需要修改
                width = 1550;
                heigth = 890;
            }

            if (fileInputName.Contains("FocusImage"))
            {
                //具体参数需要修改
                width = 300;
                heigth = 300;
            }

            if (fileInputName.Contains("AndriodDl"))
            {
                fileName = GameCenter.Core.Common.UploadFile.SaveFile(file, "apks");
            }
            else
            {
                fileName = GameCenter.Core.Common.UploadFile.SaveImage(file, fileInputName.Replace("FileData", ""), width, heigth);
            }

            return Json(new { filename = fileName, name = name });
        }


    }
}