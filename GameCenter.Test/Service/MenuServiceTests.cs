using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCenter.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.Entity.Dto;
using GameCenter.Core.Common;

namespace GameCenter.Test
{
    [TestClass()]
    public class MenuServiceTests
    {

        [TestInitialize]
        public void Init()
        {
            MapperEntity.MapperInit();
        }


        [TestMethod()]
        public void GetListCacheTest()
        {
            var msg = string.Empty;

            var list = MenuService.GetListCache();

            var info = MenuService.GetOne(1);
            info.Url = "/12345";

            var form = new MenuForm()
            {
                Id = info.Id,
                Url = info.Url,
                GameId = info.GameId,
                IsMain = true,
                Name = info.Name,
                ParentId = info.ParentId,
                Sort = info.Sort
            };
            var r = MenuService.Edit(form, out msg);

            list = MenuService.GetListCache();

            Console.Read();
        }
    }
}