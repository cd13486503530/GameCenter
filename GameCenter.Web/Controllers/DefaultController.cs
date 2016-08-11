using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core;
using GameCenter.Core.Service;
using GameCenter.Entity.Data;

namespace GameCenter.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.MainBgImages = GameInfoService.GetGameInfo(0) ?? new GameInfo(); 
            ViewBag.Menu = MenuService.GetListCache().Where(a=>a.ParentId == 0 && a.GameId == 0).ToList();
            ViewBag.Games = GameService.GetGamesCache().Where(a=>a.Top).Take(3).ToList();
            ViewBag.ImageNews = NewsService.GetHotListByGameId(0, 2, false);

            var newList = NewsService.GetHotListByGameId(0, 8, false);
            ViewBag.HotNews = newList.FirstOrDefault();
            ViewBag.News = newList.Skip(1);
            return View();
        }
    }
}