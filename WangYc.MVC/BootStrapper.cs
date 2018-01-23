using StructureMap;
using StructureMap.Configuration.DSL;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
using WangYc.Models.Repository.BW;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.HR;
using WangYc.Repository.NHibernate.Repositories.BW;
using WangYc.Services.Implementations.HR;
using WangYc.Services.Implementations.BW;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Implementations.SD;
using WangYc.Services.Interfaces.SD;
using WangYc.Models.Repository.SD;
using WangYc.Repository.NHibernate.Repositories.SD;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Core.Infrastructure.Logging;
using WangYc.Core.Infrastructure.Account;

namespace WangYc.MVC
{
    public class BootStrapper {

        public static void ConfigureDependencies() {
            ObjectFactory.Initialize(x => {
                x.AddRegistry<ControllerRegistry>();
            });
        }

        public class ControllerRegistry : Registry {

            public ControllerRegistry() {
              

                #region HR

                For<IUsersRepository>().Use<WangYc.Repository.NHibernate.Repositories.HR.UsersRepository>();
                For<IUsersService>().Use<UsersService>();

                For<IOrganizationRepository>().Use<WangYc.Repository.NHibernate.Repositories.HR.OrganizationRepository>();
                For<IOrganizationService>().Use<OrganizationService>();

                For<IRightsRepository>().Use<RightsRepository>();
                For<IRightsService>().Use<RightsService>();

                For<IRoleRepository>().Use<RoleRepository>();
                For<IRoleService>().Use<RoleService>();

                #endregion

                #region BW


                For<IInOutBoundRepository>().Use<InOutBoundRepository>();
                For<IOutBoundRepository>().Use<OutBoundRepository>();
                For<IInBoundRepository>().Use<InBoundRepository>();
                For<IInOutBoundService>().Use<InOutBoundService>();

                For<IWarehouseRepository>().Use<WarehouseRepository>();
                For<IWarehouseService>().Use<WarehouseService>();

                For<IWarehouseShelfRepository>().Use<WarehouseShelfRepository>();
                For<IWarehouseShelfService>().Use<WarehouseShelfService>();

                #endregion

                #region SD

                For<IProductRepository>().Use<ProductRepository>();
                For<IProductService>().Use<ProductService>();

                #endregion

                // Application Settings
                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
                // NH工作单元
                For<IUnitOfWork>().Use<WangYc.Repository.NHibernate.NHUnitOfWork>();
                // Logger
                For<ILogger>().Use<WangYc.Core.Infrastructure.Logging.Log4NetAdapter>();
                // Cookie
                For<ICookieStorageService>().Use<CookieStorageService>();
                // 登录验证
                For<IAuthenticationService>().Use<AuthenticationService>();
                

            }
        }

    }
}