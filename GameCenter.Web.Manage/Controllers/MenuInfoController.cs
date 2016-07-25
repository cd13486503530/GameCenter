using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.Web.Manage.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    [Active("Menu")]
    public class MenuInfoController : Controller
    {
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditForm(MenuInformation dtoInfo)
        {
            var r = false;
            if (dtoInfo.Id > 0)
            {
                var info = MenuInfoService.GetOne(dtoInfo.MenuId);
                if (info == null)
                    return Json(new { status = false, error = "参数异常" });
                r = MenuInfoService.Edit(dtoInfo);
            }
            else
            {
                r = MenuInfoService.Add(dtoInfo);
            }

            return Json(new { status = r, error = !r ? "操作失败" : "" });
        }

        // GET: MenuInfo
        public ActionResult Index(int menuId)
        {
            var info  = MenuInfoService.GetOne(menuId) ?? new MenuInformation();
            return View(info);
        }
    }
}