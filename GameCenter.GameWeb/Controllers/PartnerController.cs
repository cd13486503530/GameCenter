using GameCenter.Core.Service;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.GameWeb.Controllers
{
    public class PartnerController :BaseController
    {
        // GET: Partner
        public ActionResult Index()
        {
            var list = PartnerService.GetPartnerListBySotr(); 
            return View(list);
        }
    }
}