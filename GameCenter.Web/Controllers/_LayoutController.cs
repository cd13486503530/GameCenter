using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Controllers
{
    public class _LayoutController : Controller
    {
        
        public PartialViewResult _DescMenu(int MenuId)
        {
            var model = MenuService.GetListCache().FirstOrDefault(a => a.Id == MenuId) ?? new DtoMenu();
            ViewBag.Menu = MenuService.GetListCache().Where(a => a.ParentId == 0 && a.GameId == 0).ToList();
            ViewBag.Model = model;
            return PartialView();
        }

        public PartialViewResult _Menu(string name)
        {
            ViewBag.Menu = MenuService.GetListCache().Where(a => a.ParentId == 0 && a.GameId == 0).ToList();
            ViewBag.Name = name;
            return PartialView();
        }
    }
}