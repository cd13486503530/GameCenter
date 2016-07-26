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
        /// <summary>
        /// 用于解密和解密用户状态的密钥
        /// </summary>
        const string USERSTATUS_AES_KEY = "WE#$v%kSD@355!~~";
        /// <summary>
        /// 用户登录状态cookie名称
        /// </summary>
        const string USERSTATUS_COOKIE_NAME = "LogonUser";

        // GET: AdminUser  
        public ActionResult Login()
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
                WebUtil.WriteCookie(USERSTATUS_COOKIE_NAME, jsonuser, USERSTATUS_AES_KEY);
            }
            return Json(new { status = b, error = msg });
        }

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
                WebUtil.RemoveCookie(USERSTATUS_COOKIE_NAME);
            }
            else
            {
                return Json(new { status = b, error = msg });
            }
            return Json(new { status = b, error = msg });
        }

        public ActionResult SignOut()
        {
            WebUtil.RemoveCookie(USERSTATUS_COOKIE_NAME);
            return View("~/Views/AdminUser/Login.cshtml");
        }
    }
}