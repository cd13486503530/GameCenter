﻿using System;
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
            ViewBag.Menu = MenuService.GetListCache().Where(a => a.ParentId == 0 && a.GameId == 0).OrderBy(a => a.Sort).ToList();
            ViewBag.Games = GameService.GetGamesCache().Where(a => a.Top).Take(3).ToList();   
            ViewBag.ImageNews = NewsService.GetHotListByGameId(0, 2, true) ?? new List<Entity.Dto.DtoNews>();
            //var types = new List<int>() { 1, 2, 3, 4 };
            //var newList = NewsService.GetHotListByGameId(0, 8, false).Where(a => !types.Contains(a.NewsType));
            var newList = NewsService.GetHotListByGameId(0, 8, false);
            ViewBag.HotNews = newList.FirstOrDefault()??new Entity.Dto.DtoNews ();
            ViewBag.News = newList.Skip(1);
            return View();
        }
    }
}