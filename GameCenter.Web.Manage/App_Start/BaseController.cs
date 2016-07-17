using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.App_Start
{
    public class BaseController : Controller
    {
        // GET: Base
        public string Alert(string msg, string redirect = null)
        {
            return "<script>alert('" + msg + "');" + (!string.IsNullOrEmpty(redirect) ? "location.href='" + redirect : "")+"'</script>";
        }
    }
}