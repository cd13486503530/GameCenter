using GameCenter.Core.Common;
using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using NeedIndex.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginForm(DtoAdminUser dAdminUser)
        {
            string msg = string.Empty;
            var b = AdminUserService.AdminLogin(dAdminUser, out msg);
            if (b)
            {
                string jsonuser = dAdminUser.JSONSerialize();
                CookiesHelper.WriteCookie(jsonuser);

            }
            return Json(new { status = b, error = msg });
        }
    }
}