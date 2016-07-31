using NeedIndex.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Common
{
    public class CookiesHelper
    {
        /// <summary>
        /// 用于解密和解密用户状态的密钥
        /// </summary>
        const string USERSTATUS_AES_KEY = "WE#$v%kSD@355!~~";
        /// <summary>
        /// 用户登录状态cookie名称
        /// </summary>
        const string USERSTATUS_COOKIE_NAME = "LogonUser";

        public static string ReadCookie()
        {
            return WebUtil.ReadCookie(USERSTATUS_COOKIE_NAME, USERSTATUS_AES_KEY);
        }

        public static void WriteCookie(string jsonuser)
        {
            WebUtil.WriteCookie(USERSTATUS_COOKIE_NAME, jsonuser, USERSTATUS_AES_KEY);
        }

        public static void RemoveCookie()
        {
            WebUtil.ReadCookie(USERSTATUS_COOKIE_NAME);
        }

    }
}
