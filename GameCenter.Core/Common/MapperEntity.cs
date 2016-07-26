using AutoMapper;
using GameCenter.Core.Service;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
using GameCenter.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Common
{
    public class MapperEntity
    {
        public static void MapperInit()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Game, DtoGame>();
                cfg.CreateMap<GameForm, Game>();
                cfg.CreateMap<GameEditForm, GameForm>();
                cfg.CreateMap<GameEditForm, Game>();
                cfg.CreateMap<GameInfoForm, GameInfo>();
                cfg.CreateMap<News, DtoNews>();
                cfg.CreateMap<DtoNews, News>();
                cfg.CreateMap<NewsType, DtoNewsType>();
                cfg.CreateMap<GameInfoForm, GameInfo>();
                cfg.CreateMap<Partner, DtoPartner>();
                cfg.CreateMap<DtoPartner, Partner>();
                cfg.CreateMap<AdminUser, DtoAdminUser>();
                cfg.CreateMap<DtoAdminUser, AdminUser>();
                var map = cfg.CreateMap<GameImages, DtoGameImages>();
                map.ConstructUsing(s => new DtoGameImages
                {
                    GameName = (GameService.GetGamesCache().FirstOrDefault(a => a.Id == s.GameId) ?? new DtoGame()).Name,
                    TypeName = ((GameImageType)s.Type).ToString()
                });
                cfg.CreateMap<DtoGameImages, GameImages>();
                cfg.CreateMap<DtoMenu, Menu>();
                var menuMap = cfg.CreateMap<Menu, DtoMenu>();
                menuMap.ConstructUsing(s => new DtoMenu
                {
                    GameName = (GameService.GetGamesCache().FirstOrDefault(a => a.Id == s.GameId) ?? new DtoGame()).Name,
                });
                cfg.CreateMap<MenuForm, Menu>();
            });
        }
    }
}
