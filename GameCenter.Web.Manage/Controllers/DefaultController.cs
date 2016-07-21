using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    public class DefaultController : Controller
    {
        [HttpPost]
        // GET: Default
        public ActionResult Post(string info)
        {
            return View();
        }

        public ActionResult Index(string info)
        {
            return View();
        }
    }
}