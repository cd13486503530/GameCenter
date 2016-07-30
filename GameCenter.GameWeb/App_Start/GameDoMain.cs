using GameCenter.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web; 

namespace GameCenter.GameWeb.App_Start
{
    public class GameDoMain
    {
        internal static string DOMAIN_MAIN = Domain.MainUrl;

        public static Regex DomainPrefixRule = new Regex(@"^[\w-]{2,20}$", RegexOptions.Compiled);


        public static string GetDoMain(HttpContext context)
        {
            string domainPrefix;
            FindShopInfo(context, out domainPrefix);
            return domainPrefix;
        }

        /// <summary>
        /// 从上下文对象中找出子域名前缀
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static void FindShopInfo(HttpContext context, out string subdomain)
        {
            subdomain = null;

            string domainPrefix = null; //域名前缀
            var host = context.Request.Url.Host;

            //如果主机以本站主域结尾的
            if (!host.EndsWith(DOMAIN_MAIN, StringComparison.OrdinalIgnoreCase)
                || host.Equals(Domain.MainUrlFull, StringComparison.OrdinalIgnoreCase))
                return;
            //ert.CHEN.glass.com.cn

            domainPrefix = host.Substring(0, host.Length - DOMAIN_MAIN.Length);
            var pres = domainPrefix.Split(new char[] { '.'},StringSplitOptions.RemoveEmptyEntries);
            domainPrefix = pres.Last();
            switch (pres.Length)
            {
                case 1:
                    {
                        if (DomainPrefixRule.IsMatch(domainPrefix))
                        {
                            subdomain = domainPrefix;
                        }
                    }
                    break;
            }
        }
    }
}