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
    [Active("Menu")]
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult List(MenuForm form)
        {
            ViewBag.Games = GameService.GetGamesCache();
            ViewBag.MenuForm = form ?? new MenuForm();
            //ViewBag.GameInfo = GameService.GetGamesCache().FirstOrDefault(a=>a.Id == form.GameId);
            var list = MenuService.GetList(form);
            return View(list);
        }

        public ActionResult AddChoose()
        {
            ViewBag.Games = GameService.GetGamesCache();
            return View();
        }

        public ActionResult GameMenu(MenuForm form)
        {
            form.IsMain = false;
            ViewBag.Games = GameService.GetGamesCache();
            ViewBag.MenuForm = form ?? new MenuForm();
            var list = MenuService.GetList(form);
            return View("List", list);
        }

        public ActionResult Add(MenuForm form)
        {
            ViewBag.GameInfo = GameService.GetGamesCache().FirstOrDefault(a => a.Id == form.GameId);
            ViewBag.MenuForm = form ?? new MenuForm();
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(MenuForm menu)
        {
            var msg = string.Empty;
            var r = MenuService.Add(menu, out msg);
            return Json(new { status = r, msg = msg });
        }

        public ActionResult Edit(MenuForm req)
        {
            var menu = MenuService.GetOne(req.Id) ?? new DtoMenu();
            ViewBag.MenuForm = req ?? new MenuForm();
            return View(menu);
        }

        [HttpPost]
        public ActionResult EditPost(MenuForm menu)
        {
            var msg = string.Empty;
            var r = MenuService.Edit(menu, out msg);
            return Json(new { status = r, msg = msg });
        }

        public ActionResult Disable(int id)
        {
            var info = MenuService.GetOne(id);
            info.Disable = true;
            var r = MenuService.Disable(info);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Enabled(int id)
        {
            var info = MenuService.GetOne(id);
            info.Disable = false;
            var r = MenuService.Disable(info);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}