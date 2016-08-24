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
            ViewBag.Name = "游戏首页";
            ViewBag.Title = GameInfo.Name + "官方网站";
            ViewBag.MainBgImages = GameInfoService.GetGameInfo(GameInfo.Id) ?? new GameInfo();
            ViewBag.Menu = MenuService.GetListCache().Where(a => a.ParentId == 0 && a.GameId == GameInfo.Id).OrderBy(a=>a.Sort).ToList();
            
            //新闻
            ViewBag.Type1 = NewsService.GetHotListByGameId(NewsTypeService.GetOneByName("综合").Id, 7, false); // 综合
            ViewBag.Type2 = NewsService.GetHotListByGameId(NewsTypeService.GetOneByName("新闻").Id, 7, false); // 新闻
            ViewBag.Type3 = NewsService.GetHotListByGameId(NewsTypeService.GetOneByName("公告").Id, 7, false); // 公告
            ViewBag.Type4 = NewsService.GetHotListByGameId(NewsTypeService.GetOneByName("活动").Id, 7, false); // 活动

            return View(this.GameDesc);
        }
    }
}