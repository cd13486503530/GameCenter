using GameCenter.Core.Common;
using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    public class PartnerController : Controller
    {
        // GET: Partner
        public ActionResult Info(int id)
        {
            var info = PartnerService.GetOneById(id);
            return View(info);
        }

        public ActionResult List(DtoPartner dPartner)
        {
            var list = PartnerService.GetPartnerList(dPartner);
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddForm(DtoPartner dPartner)
        {
            string msg = string.Empty;
            HttpPostedFileBase file = Request.Files["Filedata"];
            var b = PartnerService.AddPartner(dPartner, file, out msg);
            return Json(new { statust = b, error = msg });
        }

        public ActionResult Edit(int id)
        {
            var info = PartnerService.GetOneById(id);
            return View(info);
        }
        [HttpPost]
        public ActionResult EditForm(DtoPartner dPartner)
        {
            string msg = string.Empty;
            var info = PartnerService.GetOneById(dPartner.Id);
            if (info.Id == 0)
            {
                return Json(new { status = false, error = "参数错误" });
            }
            HttpPostedFileBase file = Request.Files["Filedata"];
            var b = PartnerService.Update(dPartner, file, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Delete(int id)
        {
            string msg = string.Empty;
            var b = PartnerService.Delete(id, out msg);
            return Json(new { status = b, error = msg });
        }
    }
}