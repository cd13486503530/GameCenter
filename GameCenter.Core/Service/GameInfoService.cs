using AutoMapper;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Service
{
    public class GameInfoService
    {
        public static GameInfo GetGameInfo(int gameId)
        {
            using (var db = new PortalContext())
            {
                var info = db.GameInfos;
                return info.FirstOrDefault(a => a.GameId == gameId);
            }
        }

        public static bool Update(GameInfoForm form, GameInfo info, out string msg, bool isCheck = true)
        {
            msg = string.Empty;
            if (isCheck)
            {
                var check = Check(form, out msg);
                if (!check)
                    return false;
            }

            using (var db = new PortalContext())
            {

                var updateInfo = Mapper.Map<GameInfo>(form);
                db.Set<GameInfo>().Attach(updateInfo);
                db.Entry(updateInfo).State = System.Data.Entity.EntityState.Modified;

                return db.SaveChanges() > 0;
            }
        }


        public static bool Add(GameInfoForm form, out string msg, bool isCheck = true)
        {
            msg = string.Empty;
            if (isCheck)
            {
                var check = Check(form, out msg);
                if (!check)
                    return false;
            }


            using (var db = new PortalContext())
            {
                var info = Mapper.Map<GameInfo>(form);
                db.GameInfos.Add(info);
                return db.SaveChanges() > 0;
            }
        }

        private static bool Check(GameInfoForm form, out string msg)
        {
            msg = string.Empty;

            //if (string.IsNullOrEmpty(form.AndriodDl))
            //{
            //    msg = "安卓下载地址不能为空";
            //    return false;
            //}

            //if (string.IsNullOrEmpty(form.IosDl))
            //{
            //    msg = "AppStore下载地址不能为空";
            //    return false;
            //}

            if (string.IsNullOrEmpty(form.QrCodeImage))
            {
                msg = "二维码下载地址不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(form.BgImage0) && string.IsNullOrEmpty(form.BgImage1) && string.IsNullOrEmpty(form.BgImage2) && string.IsNullOrEmpty(form.BgImage3))
            {
                msg = "至少上传一张游戏首页背景图片";
                return false;
            }

            if (string.IsNullOrEmpty(form.FocusImage0) && string.IsNullOrEmpty(form.FocusImage1) && string.IsNullOrEmpty(form.FocusImage2) && string.IsNullOrEmpty(form.FocusImage3))
            {
                msg = "至少上传一张游戏首页焦点图片";
                return false;
            }
            return true;
        }
    }
}
