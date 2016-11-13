using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using GameCenter.Web.Manage.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.Web.Manage.Controllers
{
    [Active("Channel")]
    public class ChannelController : Controller
    {
        // GET: Channel

        public ActionResult List()
        {
            var list = ChannelService.GetListALL();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var info = ChannelService.GetOneById(id);
            return View(info);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddForm(DtoChannel channel)
        {
            string msg = string.Empty;  
            var b = ChannelService.Add(channel, out msg);
            return Json(new { status = b, error = msg });
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditForm(DtoChannel channel)
        {
            string msg = string.Empty;
            var info = ChannelService.GetOneById(channel.Id);
            if (info.Id == 0)
            {
                return Json(new { status = false, error = "参数错误" });
            } 
            var b = ChannelService.Update(channel, out msg);
            return Json(new { status = b, error = msg });
        }

        public ActionResult Delete(int id)
        {
            string msg = string.Empty;
            var b = ChannelService.Delete(id, out msg);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}