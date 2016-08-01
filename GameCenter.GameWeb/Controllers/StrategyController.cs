using GameCenter.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.GameWeb.Controllers
{
    public class StrategyController : Controller
    {
        // GET: Strategy
        public ActionResult Index()
        {
            var list = NewsService.GetListByTypeId(1, 10);
            return View(list);
        }

        public ActionResult Info(int id)
        {
            var info = NewsService.GetOneById(id);
            return View(info);
        }
    }
}