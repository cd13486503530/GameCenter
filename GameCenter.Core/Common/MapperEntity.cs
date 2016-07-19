using AutoMapper;
using GameCenter.Entity.Data;
using GameCenter.Entity.Dto;
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
                cfg.CreateMap<GameEditForm,GameForm> ();
                cfg.CreateMap<GameEditForm, Game>();
                cfg.CreateMap<GameInfoForm,GameInfo>();
            });
        }
    }
}
