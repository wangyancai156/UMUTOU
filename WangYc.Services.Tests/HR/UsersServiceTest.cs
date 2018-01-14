using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Core.Infrastructure.Domain;
 
using WangYc.Models.Repository.HR;

using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.HR;

using WangYc.Services.Interfaces;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Implementations.HR;
using WangYc.Services.Mapping.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Models.HR;
using WangYc.Services.ViewModels;


namespace WangYc.Services.Tests
{
    [TestClass]
    public class UsersServiceTest
    {
        private readonly IUsersService _userService;
        private readonly IOrganizationService _organizationService;
        public UsersServiceTest() {

            IUnitOfWork uow = new NHUnitOfWork();
            IUsersRepository _usersRepository = new UsersRepository(uow);

            IOrganizationRepository _organizationRepository = new OrganizationRepository(uow);

            this._userService = new UsersService(_usersRepository, _organizationRepository, uow);
            this._organizationService = new OrganizationService(_organizationRepository, uow);
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }


        [TestCategory("根据userID获取user实体")]
        [TestMethod]
        public void FindUsersByTest() {

            string userId = "D55";
            UsersView user = _userService.FindUsersBy(userId);
             
        }

        [TestMethod]
        public void GetOrganization() {
            IEnumerable<DataTreeView> organization = this._organizationService.GetOrganizationTreeView();
        }
    }
}
