using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Core.Service;
using GameCenter.Entity.Dto;
using GameCenter.GameWeb.App_Start;
using System.Text;

namespace GameCenter.GameWeb.Controllers
{
    public class MapController : BaseController
    {
        // GET: Map
        public ActionResult Index(GameImagesForm req)
        {
            int total = 0;
            req.PageSize = 1;
            req.Type = 2;
            req.GameId = this.GameInfo.Id;
            var info = MenuService.GetOne(req.MenuId) ?? new DtoMenu();

            ViewBag.Name = "游戏介绍";
            ViewBag.TypeName = info.Name;
            var list = GameImagesService.GetPageList(req, out total);
            ViewBag.HtmlPage = HtmlPage(req,total);
            return View(list.FirstOrDefault() ?? new DtoGameImages());
        }

        private string HtmlPage(GameImagesForm req, int total)
        {
            // <a href=""><img src="/content/img/left-icon.png" alt="" class="prev-img"></a>
            //< a href = "" >< img src = "/content/img/right-icon.png" alt = "" class="next-img"></a>

            StringBuilder sb = new StringBuilder();
            int pre = req.PageIndex - 1;
            int next = req.PageIndex + 1;
            if (pre < 1)
            {
                pre = 1;
            } 

            if (next > total)
            {
                next = total;
            }
           

            sb.Append("<a href=\"/Map?pageindex=" + pre + "\"><img src=\"/content/img/left-icon.png\" class=\"prev-img\"></a>");
            sb.Append("<a href=\"/Map?pageindex=" + next + "\"><img src=\"/content/img/right-icon.png\" class=\"next-img\"></a>");

            return sb.ToString();
        }
    }
}