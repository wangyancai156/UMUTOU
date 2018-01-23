using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.VisualStudio.TestTools.UnitTesting;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Core.Infrastructure.Domain;

using WangYc.Models.HR;
using WangYc.Models.Repository.HR;

using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.HR;

using WangYc.Services.Implementations.HR;
using WangYc.Services.Mapping.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Interfaces.HR;

namespace WangYc.Services.Tests
{
    [TestClass]
     public class RightsServiceTest
    {

        private readonly IRightsService _rightsService;
        public RightsServiceTest()
         {

            IUnitOfWork uow = new NHUnitOfWork();
            IRightsRepository _rightsRepository = new RightsRepository(uow);

            this._rightsService = new RightsService(_rightsRepository, uow);
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }

         [TestCategory("货期所有职位信息")]
         [TestMethod]
         public void FindUsersByTest()
         {
             IEnumerable<RightsView> user = _rightsService.GetRightsView(1002);
         }

    }
}
