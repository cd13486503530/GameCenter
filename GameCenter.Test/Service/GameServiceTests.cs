using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCenter.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.Core;
using GameCenter.Core.Common;
using GameCenter.Entity.Dto;

namespace GameCenter.Test
{
    [TestClass()]
    public class GameServiceTests
    {
        [TestInitialize]
        public void Init()
        {
            MapperEntity.MapperInit();
        }


        [TestMethod()]
        public void GetGamesTest()
        {
            var list = GameService.GetGames();

        }

        [TestMethod()]
        public void AddTest()
        {
            var msg = string.Empty;
            var news = new GameForm() {
                Code = "test",
                ImagePath ="",
                Desc="etst",
                Name="test Game",
                Top=false
            };
            //var r = GameService.Add(news,null,out msg);
            
        }
    }
}