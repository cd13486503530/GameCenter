using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core.Service;
using GameCenter.GameWeb.App_Start;
using GameCenter.Entity.Enum;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using GameCenter.Core.Common;
using NeedIndex.Utility.Extensions;

namespace GameCenter.GameWeb.Controllers
{
    public class GameImagesController : BaseController
    {
        // GET: GameImages
        public ActionResult Info(int type = 0,int menuId=0,int cp = 1)
        {
            if (type == 0)
                return View(new GameImages());

            ViewBag.Name = "游戏介绍";
            var image = GameImagesService.GetOneByTypeId(type, this.GameInfo.Id) ?? new GameImages();
            var info = MenuService.GetOne(menuId) ?? new DtoMenu();
            ViewBag.TypeName = info.Name;
            //<hr style=\"page-break-after:always;\" class=\"ke-pagebreak\" />
            var contentPage = image.Info.SplitRemoveEmpty("<hr style=\"page-break-after:always;\" class=\"ke-pagebreak\" />");
            var cpHTML = string.Empty;
            if (contentPage.Length > 1)
            {
                cpHTML = PageHelper.NewsPager(contentPage.Length, cp, 1);
            }

            image.Info = contentPage[cp - 1] + cpHTML;

            return View(image);
        }

      
    }
}