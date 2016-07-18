using GameCenter.Data;
using GameCenter.Entity.Data;
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
                var info = db.GameInfos.FirstOrDefault(a=>a.GameId == gameId);
                return info;
            }
        }
    }
}
