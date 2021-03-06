﻿using GameCenter.Core.Service;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeedIndex.Utility.Extensions;
using GameCenter.Core.Common;
using GameCenter.Entity.Dto;

namespace GameCenter.GameWeb.Controllers
{
    public class NewsController :BaseController
    {
        // GET: News
        public ActionResult Index()
        {
            ViewBag.News1 = NewsService.GetListByTypeId(1, 10);
            ViewBag.News2 = NewsService.GetListByTypeId(2, 10);
            ViewBag.News3 = NewsService.GetListByTypeId(3, 10);
            ViewBag.News4 = NewsService.GetListByTypeId(4, 10);
            return View();
        }

        public ActionResult Info(int id)
        {
            var info = NewsService.GetOneById(id);
           
            return View(info);
        }

        public ActionResult ResourceList()
        {
            var list = NewsService.GetListByTypeId(5, 10);
            return View(list);
        }

        public ActionResult ResourceInfo(int id)
        {
            var info = NewsService.GetOneById(id);
            return View(info);
        }

        /// <summary>
        /// 游戏攻略
        /// </summary>
        /// <returns></returns>
        public ActionResult Strategy(int menuId=0)
        {
            ViewBag.News = NewsService.GetListByTypeId(5, 20)??new List<DtoNews> ();
            ViewBag.News1 = NewsService.GetListByTypeId(6, 20) ?? new List<DtoNews>();
            ViewBag.News2 = NewsService.GetListByTypeId(7, 20) ?? new List<DtoNews>();
            var info = MenuService.GetOne(menuId) ?? new DtoMenu();
            ViewBag.TypeName = info.Name;
            return View();
        }
    }
}