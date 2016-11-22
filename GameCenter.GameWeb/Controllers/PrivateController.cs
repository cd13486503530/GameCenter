using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.GameWeb.Controllers
{
    public class PrivateController : BaseController
    {
        // GET: Private
        public ActionResult Index(int id = 0)
        {
            DtoPrivatePage info = null;
            if (id == 0)
            {
                info = PrivatePageService.GetInfoByGameId(GameInfo.Id);                
            }
            else
            {
                var chaneel = ChannelService.GetOneById(id);
                if (chaneel.Id == 0)
                {
                    return Redirect("~/404.html");
                }

                info = PrivatePageService.GetInfoByGameId(GameInfo.Id, id);
            }
            //info = PrivatePageService.GetInfoByGameId(2);
            ViewBag.GameName = this.GameInfo.Name; 
            return View(info);
        }
    }
}