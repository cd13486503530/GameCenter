using GameCenter.Core.Cache;
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
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var httpContext = HttpContext.Current;
            if (httpContext.Request.Url.AbsolutePath.EndsWith("/error.html", StringComparison.OrdinalIgnoreCase))
                return;
            
            var domain = GameDoMain.GetDoMain(httpContext);
            if (string.IsNullOrEmpty(domain))
                httpContext.Response.Redirect("/404.html");

            
        }
    }
}
