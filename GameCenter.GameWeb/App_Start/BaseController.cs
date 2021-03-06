﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Entity.Dto;
using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.Core.Cache;

namespace GameCenter.GameWeb.App_Start
{
    public class BaseController : Controller
    {
        public DtoGame GameInfo { get; set; }

        public string DoMain { get; set; }

        public GameInfo GameDesc { get; set; }

        public BaseController()
        {
            DoMain = GameDoMain.GetDoMain(System.Web.HttpContext.Current);
            //GameInfo = GameService.GetOneByName(DoMain) ?? new DtoGame(); 
            GameInfo = LocalCache.Instance().Get<DtoGame>(DoMain);
            GameDesc = GameInfoService.GetGameInfo(GameInfo.Id) ?? new GameInfo();
            ViewBag.Logo = GameCenter.Core.Common.Domain.GetImage(GameDesc.Logo);// /Content/img/ling-logo.png          
            ViewBag.Icon = GameCenter.Core.Common.Domain.GetImage(GameDesc.Icon);
        }
    }
}