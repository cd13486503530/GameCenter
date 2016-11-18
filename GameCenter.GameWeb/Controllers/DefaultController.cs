using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.GameWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenter.GameWeb.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Default
        public ActionResult Index()
        {
            var seoInfo = SeoService.GetInfo(this.GameInfo.Id, 12);

            ViewBag.Name = "游戏首页";
            ViewBag.Title = seoInfo.Title;
            ViewBag.Keywords = seoInfo.Keywords;
            ViewBag.Description = seoInfo.Description;
            ViewBag.MainBgImages = GameInfoService.GetGameInfo(GameInfo.Id) ?? new GameInfo();
            ViewBag.Menu = MenuService.GetListCache().Where(a => a.ParentId == 0 && a.GameId == GameInfo.Id).OrderBy(a=>a.Sort).ToList();
            
            //新闻
            ViewBag.Type1 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("综合").Id, 7); // 综合
            //ViewBag.Type2 = NewsService.GetHotListByGameId(NewsTypeService.GetOneByName("新闻").Id, 7, false); // 新闻
            ViewBag.Type2 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("新闻").Id, 7);
            ViewBag.Type3 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("公告").Id, 7); // 公告
            ViewBag.Type4 = NewsService.GetListByTypeId(NewsTypeService.GetOneByName("活动").Id, 7); // 活动

            return View(this.GameDesc);
        }
    }
}