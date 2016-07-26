using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.App_Start
{
    public class ActiveAttribute : AuthorizeAttribute
    {
        private string _currentActive;
        public ActiveAttribute(string active)
        {
            _currentActive = active;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.Active = _currentActive;
            // base.OnAuthorization(filterContext);
        }

    }
}