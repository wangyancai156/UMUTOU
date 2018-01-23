using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.BW;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.BW;
using WangYc.Models.BW;

namespace WangYc.Services.Tests.BW {
    [TestClass]
    public class WarehouseShelfTest {

        private readonly IWarehouseShelfRepository _warehouseShelfRsponstroy;

        public WarehouseShelfTest() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._warehouseShelfRsponstroy = new WarehouseShelfRepository(uow);
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }

        [TestMethod]
        public void GetWarehouseShelf() {

            IEnumerable<WarehouseShelf> model = this._warehouseShelfRsponstroy.FindAll();
        }

    }
}
