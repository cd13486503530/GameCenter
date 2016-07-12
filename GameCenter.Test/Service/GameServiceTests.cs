using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCenter.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Test
{
    [TestClass()]
    public class GameServiceTests
    {
        [TestMethod()]
        public void GetGamesTest()
        {
            var list = GameService.GetGames();
            
        }
    }
}