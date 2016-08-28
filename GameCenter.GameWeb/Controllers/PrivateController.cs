using GameCenter.Core.Service;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.GameWeb.Controllers
{
    public class PrivateController : BaseController
    {
        // GET: Private
        public ActionResult Index()
        {
            var info = PrivatePageService.GetInfoByGameId(GameInfo.Id);
            ViewBag.GameName = this.GameInfo.Name;
            return View(info);
        }
    }
}