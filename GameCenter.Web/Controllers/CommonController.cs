using GameCenter.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Remove()
        {

            //LocalCache.Instance().Remove(key);
            return Json(new { s = true });
        }
    }
}