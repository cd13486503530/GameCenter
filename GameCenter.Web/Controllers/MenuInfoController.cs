using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core.Service;
using GameCenter.Web.App_Start;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;

namespace GameCenter.Web.Controllers
{
    public class MenuInfoController : Controller
    {
        public ActionResult Info(int MenuId)
        {
            var info = MenuInfoService.GetOne(MenuId) ?? new MenuInformation ();
          
            return View(info);
        }
    }
}