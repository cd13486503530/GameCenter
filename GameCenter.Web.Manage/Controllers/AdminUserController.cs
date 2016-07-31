using GameCenter.Core.Common;
using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using GameCenter.Web.Manage.App_Start;
using NeedIndex.Utility;
using NeedIndex.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    [Active("AdminUser")]
    public class AdminUserController : Controller
    {

        // GET: AdminUser   

        public ActionResult Edit()
        {
            var info = AdminUserService.GetUserAndPassWord();
            return View(info);
        }

        [HttpPost]
        public ActionResult EditForm(DtoAdminUser dAdminUser)
        {
            string msg = string.Empty;
            var b = AdminUserService.UpdatePassWord(dAdminUser, out msg);
            if (b)
            {
                CookiesHelper.ReadCookie();
            }
            else
            {
                return Json(new { status = b, error = msg });
            }
            return Json(new { status = b, error = msg });
        }
        [HttpGet]
        public ActionResult SignOut()
        {
            CookiesHelper.ReadCookie();
            return Redirect("/Login/Index");
        }
    }
}