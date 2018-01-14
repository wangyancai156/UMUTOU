using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WangYc.Models.Repository.SD;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.SD;

namespace WangYc.Services.Tests.SD {
    [TestClass]
    public class ProductTest {

        private readonly IProductRepository _productRsponstroy;
 
        public ProductTest() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._productRsponstroy = new ProductRepository(uow);
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }

        [TestMethod]
        public void GetProduct() {

            this._productRsponstroy.FindAll();
        }

    }
}
