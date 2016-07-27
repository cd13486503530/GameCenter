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
        // GET: _Layout
        public PartialViewResult _Menu(int MenuId)
        {
            var model = MenuService.GetListCache().FirstOrDefault(a => a.Id == MenuId) ?? new DtoMenu();
            ViewBag.Menu = MenuService.GetListCache().Where(a => a.ParentId == 0 && a.GameId == 0).ToList();
            ViewBag.Model = model;
            ViewBag.Active = model.Name;
            return PartialView();
        }
    }
}