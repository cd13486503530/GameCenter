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
            var game = GameService.GetGamesCache().FirstOrDefault(a => a.Id == gameId) ?? new DtoGame();
            ViewBag.GameId = gameId;
            ViewBag.GameInfo = game;
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
        public ActionResult UploadFile(UploadForm req)
        {
            var fileName = string.Empty;
            var file = Request.Files[0];
            var fileInputName = Request.Files.AllKeys[0];
            var t = Request["t"]; //上传来原
            var name = file.FileName;
            if (fileInputName.Contains("BgImage"))
            {
                //具体参数需要修改
                req.Width = 1920;
                req.Heigth = 1062;
            }

            if (fileInputName.Contains("FocusImage"))
            {
                //具体参数需要修改
                req.Width = 490;
                req.Heigth = 320;
            }

            if (fileInputName.Contains("AndriodDl"))
            {
                fileName = GameCenter.Core.Common.UploadFile.SaveFile(file, "apks");
            }
            else if (fileInputName.Contains("VedioUrl"))
            {
                fileName = GameCenter.Core.Common.UploadFile.SaveFile(file, "media");
            }
            else
            {
                fileName = GameCenter.Core.Common.UploadFile.SaveImage(file, fileInputName.Replace("FileData", ""), req.Width, req.Heigth);
            }


            if (t == "kindeditor")
            {
                // error、messag、url 为kindeditor返回参数
                return Json(new { error = 0, filename = fileName, name = name, message = "", url = GameCenter.Core.Common.Domain.GetImage(fileName) });
            }
            else
            {
                return Json(new { filename = fileName, name = name });
            }
        }


    }
}