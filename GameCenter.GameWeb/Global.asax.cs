using GameCenter.Core.Cache;
using GameCenter.Core.Common;
using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GameCenter.GameWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperEntity.MapperInit();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var httpContext = HttpContext.Current;
            if (httpContext.Request.Url.AbsolutePath.EndsWith("/error.html", StringComparison.OrdinalIgnoreCase))
                return;

            var domain = GameDoMain.GetDoMain(httpContext);
            var gameInfoCache = LocalCache.Instance().Get<DtoGame>(domain);
            if (gameInfoCache == null)
            {
                gameInfoCache = GameService.GetOneByName(domain) ?? new DtoGame();
                LocalCache.Instance().Set(domain,gameInfoCache, DateTime.Now.AddMinutes(10));
            }

            if (gameInfoCache.Disable)
                httpContext.Response.Redirect("/404.html");

            if (string.IsNullOrEmpty(domain))
                httpContext.Response.Redirect("/404.html");


        }
    }
}
