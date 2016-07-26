using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core.Service;
using GameCenter.Web.App_Start;

namespace GameCenter.Web.Controllers
{
    public class MenuInfoController : Controller
    {
        [Active("")]
        // GET: MenuInfo
        public ActionResult Info(int MenuId)
        {
            var info = MenuInfoService.GetOne(MenuId) ?? new Entity.Data.MenuInformation ();  
            ViewBag.Menu = MenuService.GetListCache().Where(a => a.ParentId == 0 && a.GameId == 0).ToList();
            return View(info);
        }
    }
}