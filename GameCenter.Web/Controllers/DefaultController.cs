using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core;
using GameCenter.Core.Service;

namespace GameCenter.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.MainBgImages = GameInfoService.GetGameInfo(0);
            return View();
        }
    }
}