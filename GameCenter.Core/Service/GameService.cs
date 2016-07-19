using AutoMapper;
using GameCenter.Core.Common;
using GameCenter.Data;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using GameCenter.Core.Cache;

namespace GameCenter.Core.Service
{
    public class GameService
    {
        private static string UPLAOD_TAG = "Cover"; //游戏封面
        private static int ThumbnailImage_Width = 430;
        private static int ThumbnailImage_Heigth = 270;

        public static List<DtoGame> GetGames()
        {
            using (var db = new PortalContext())
            {
                var list = db.Games.Take(5).ToList();
                return Mapper.Map<List<DtoGame>>(list);
            }
        }

        public static List<DtoGame> GetGamesCache()
        {   
            var key = "GameCenter.Core.Service.GameService.GetGamesCache";
            var cacheInfo = LocalCache.Instance().Get<List<DtoGame>>(key);
            if (cacheInfo == null)
            {
                var games = GetGames();
                LocalCache.Instance().Set(key, games, DateTime.Now.AddDays(1).TimeOfDay);
                return games;
            }

            return cacheInfo;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="form"></param>
        /// <param name="outConut"></param>
        /// <returns></returns>
        public static List<DtoGame> GetPageList(GameListForm form, out int outConut)
        {
            outConut = 0;
            IQueryable<Game> list = null;
            using (var db = new PortalContext())
            {
                var listexpre = new List<Expression>();
                //依据IQueryable数据源构造一个查询
                IQueryable<Game> custs = db.Games;
                //组建一个表达式树来创建一个参数
                ParameterExpression param = Expression.Parameter(typeof(Game), "c");
                Expression filter = null;
                if (!string.IsNullOrEmpty(form.Name))
                {
                    filter = ExpressionExtension<Game>.GenExpre(param, "Name", form.Name);
                    listexpre.Add(filter);
                }

                if (!string.IsNullOrEmpty(form.Code))
                {
                    //list.Where(a=> SqlFunctions.PatIndex("%"+form.Code+"%", a.Code) > 0); 
                    filter = ExpressionExtension<Game>.GenExpre(param, "Code", form.Code);
                    listexpre.Add(filter);
                }

                if (form.Disable != null)
                {
                    filter = ExpressionExtension<Game>.GenExpre(param, "Disable", form.Disable.Value);
                    listexpre.Add(filter);
                }

                if (form.Top != null)
                {
                    filter = ExpressionExtension<Game>.GenExpre(param, "Top", form.Top.Value);
                    listexpre.Add(filter);
                }

                var andFilter = listexpre.Count > 0 ? listexpre.Aggregate(Expression.AndAlso) : null;

                if (andFilter != null)
                {
                    list = db.Games.Where(Expression.Lambda<Func<Game, bool>>(andFilter, param));

                }
                else
                {
                    list = db.Games;
                }
                outConut = list.Count();

                list = list.OrderByDescending(a => a.Id).Skip((form.PageIndex - 1) * form.PageSize).Take(form.PageSize);

                return Mapper.Map<List<DtoGame>>(list.ToList());
            }
        }


        /// <summary>
        /// 包含重复游戏名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ContainsGameName(string name)
        {
            using (var db = new PortalContext())
            {
                return db.Games.Count(a => a.Name == name);
            }
        }

        /// <summary>
        /// 不包含除本身外的游戏名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int ContainsGameNameNotSelf(string name, int id)
        {
            using (var db = new PortalContext())
            {
                return db.Games.Count(a => a.Name == name && a.Id != id);
            }
        }

        /// <summary>
        /// 根据Id获取游戏数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Game GetGameOne(int id)
        {
            using (var db = new PortalContext())
            {
                return db.Games.FirstOrDefault(a => a.Id == id);
            }
        }

        /// <summary>
        /// 增加游戏
        /// </summary>
        /// <param name="req"></param>
        /// <param name="file"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Add(GameForm req, HttpPostedFileBase file, out string msg)
        {
            msg = string.Empty;
            var check = CheckAddForm(req, file, out msg);
            if (!check)
                return false;

            var imagePath = UploadFile.SaveImage(file, UPLAOD_TAG, ThumbnailImage_Width,ThumbnailImage_Heigth);
            if (string.IsNullOrEmpty(imagePath))
            {
                msg = "上传失败";
                return false;
            }

            using (var db = new PortalContext())
            {
                var game = Mapper.Map<Game>(req);
                game.ImagePath = imagePath;
                db.Games.Add(game);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 编辑游戏
        /// </summary>
        /// <param name="req"></param>
        /// <param name="file"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Edit(GameEditForm req, Game source, HttpPostedFileBase file, out string msg)
        {
            msg = string.Empty;
            var check = CheckEditForm(req, file, out msg);
            if (!check)
                return false;
            using (var db = new PortalContext())
            {
                var game = Mapper.Map<Game>(req);

                if (file != null)
                {
                    var newFile = UploadFile.SaveImage(file, UPLAOD_TAG, ThumbnailImage_Width, ThumbnailImage_Heigth);
                    game.ImagePath = newFile;
                }

                db.Set<Game>().Attach(game);
                db.Entry(game).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 添加游戏时验证参数
        /// </summary>
        /// <param name="req"></param>
        /// <param name="file"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static bool CheckAddForm(GameForm req, HttpPostedFileBase file, out string msg)
        {
            if (!CheckForm(req, file, out msg))
            {
                return false;
            }

            if (file == null)
            {
                msg = "游戏封面不能为空";
                return false;
            }

            var count = ContainsGameName(req.Name);
            if (count > 0)
            {
                msg = "游戏名称已存在";
                return false;
            }

            return true;
        }

        private static bool CheckEditForm(GameEditForm req, HttpPostedFileBase file, out string msg)
        {
            var gameForm = Mapper.Map<GameForm>(req);
            if (!CheckForm(gameForm, file, out msg))
            {
                return false;
            }

            var count = ContainsGameNameNotSelf(req.Name, req.Id);
            if (count > 0)
            {
                msg = "游戏名称已存在";
                return false;
            }

            return true;
        }

        private static bool CheckForm(GameForm req, HttpPostedFileBase file, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrWhiteSpace(req.Name) || req.Name.Length > 32)
            {
                msg = "游戏名称为空或者长度超过32位";
                return false;
            }
            if (string.IsNullOrWhiteSpace(req.Name) || req.Name.Length > 32)
            {
                msg = "游戏缩写为空或者长度超过32位";
                return false;
            }

            return true;
        }
    }
}
