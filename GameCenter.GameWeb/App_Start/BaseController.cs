using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameCenter.Entity.Dto;
using GameCenter.Core.Service;

namespace GameCenter.GameWeb.App_Start
{
    public class BaseController : Controller
    {
        public DtoGame GameInfo { get; set; }

        public string DoMain { get; set; } 

        public BaseController()
        {
            DoMain = GameDoMain.GetDoMain(System.Web.HttpContext.Current);
            GameInfo = GameService.GetOneByName(DoMain) ?? new DtoGame();
           
        }
    }
}