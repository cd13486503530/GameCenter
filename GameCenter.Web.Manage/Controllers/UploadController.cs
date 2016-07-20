using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost] 
        public ActionResult Index(UploadForm form)
        {
            return View();
        }
    }
}