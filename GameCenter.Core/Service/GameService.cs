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
    public class GameService
    {
        public static List<DtoGame> GetGames()
        {
            using (var db = new PortalContext())
            {
                var list = db.Games.Take(5).ToList();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Game, DtoGame>();
                });
                return Mapper.Map<List<DtoGame>>(list);
            }
        }
    }
}
