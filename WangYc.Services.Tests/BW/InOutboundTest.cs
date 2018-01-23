using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Repository.NHibernate;

using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Repository.NHibernate.Repositories.BW;

using WangYc.Services.Interfaces.BW;
using WangYc.Services.Implementations.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Models.Repository.SD;
using WangYc.Repository.NHibernate.Repositories.SD;

namespace WangYc.Services.Tests.BW {
    [TestClass]
    public class InOutBoundTest {

        private readonly IInOutBoundRepository _inOutBoundRsponstroy;
        private readonly IOutBoundRepository _outBoundRsponstroy;
        private readonly IInBoundRepository _inBoundRsponstroy;
        private readonly IInOutBoundService _inOutBoundService;
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IWarehouseShelfRepository _warehouseShelfRepository;
        public InOutBoundTest() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._outBoundRsponstroy = new OutBoundRepository(uow);
            this._inBoundRsponstroy = new InBoundRepository(uow);
            this._inOutBoundRsponstroy = new InOutBoundRepository(uow);
            this._productRepository = new ProductRepository(uow);
            this._warehouseRepository = new WarehouseRepository(uow);
            this._warehouseShelfRepository = new WarehouseShelfRepository(uow);
            this._inOutBoundService = new InOutBoundService(_inOutBoundRsponstroy, _outBoundRsponstroy, _inBoundRsponstroy, _productRepository, _warehouseRepository, _warehouseShelfRepository, uow);

            AutoMapperBootStrapper.ConfigureAutoMapper();
        }

        [TestCategory("获取库存信息")]
        [TestMethod]
        public void GetInOutBound() {

            // IEnumerable<OutBound> outs = this._outBoundRsponstroy.FindAll();
            IEnumerable<InBoundView> ins = this._inBoundRsponstroy.FindAll().ConvertToInBoundView();
            
            //IEnumerable<InOutBound> model = this._inOutBoundRsponstroy.FindAll();

            //Query query  = new Query();
            // IEnumerable<InOutBound> inout = this._inOutBoundService.GetInOutBound(query);

        }
 
    }
}
