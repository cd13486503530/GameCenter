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

namespace GameCenter.Core.Service
{
    public class GameService
    {
        public static List<DtoGame> GetGames()
        {
            using (var db = new PortalContext())
            {
                var list = db.Games.Take(5).ToList();
                return Mapper.Map<List<DtoGame>>(list);
            }
        }

        public static List<DtoGame> GetPageList(GameListForm form,out int outConut)
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
                    filter =ExpressionExtension<Game>.GenExpre(param, "Name", form.Name);
                    listexpre.Add(filter);
                }

                if (!string.IsNullOrEmpty(form.Code))
                {
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

                list = list.OrderByDescending(a=>a.Id).Skip((form.PageIndex - 1) * form.PageSize).Take(form.PageSize);
               
                return Mapper.Map<List<DtoGame>>(list.ToList());
            }
        }

       

        public static int ContainsGameName(string name)
        {
            using (var db = new PortalContext())
            {
                return db.Games.Count(a => a.Name == name);
            }
        }


        public static Game GetGameOne(int id)
        {
            using (var db = new PortalContext())
            {
                return db.Games.FirstOrDefault(a=>a.Id == id);
            }
        }


        public static bool Add(GameForm req, HttpPostedFileBase file, out string msg)
        {
            msg = string.Empty;
            var check = CheckAddForm(req, file, out msg);
            if (!check)
                return false;

            var imagePath = UploadFile.SaveFile(file);
            if (string.IsNullOrEmpty(imagePath))
            {
                msg = "删除失败";
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


        public static bool Edit(GameEditForm req,HttpPostedFileBase file,out string msg)
        {
            msg = string.Empty;
            return true;
        }


        private static bool CheckAddForm(GameForm req, HttpPostedFileBase file, out string msg)
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
    }
}
