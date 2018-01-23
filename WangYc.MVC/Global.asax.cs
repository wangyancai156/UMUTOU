//using System;
//using System.Collections.Generic;
//using System.Web;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
//using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
//using System.Web.Mvc;
//using System.Web.Http;
//using System.Web.Routing;
//using System.Web.Optimization;
//using WangYc.Services;
//using WangYc.Core.Infrastructure.Configuration;
//using StructureMap;
//using System.Web.Security;
//using WangYc.Controllers;
//using System.Security.Principal;
//using WangYc.Core.Infrastructure.Security;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WangYc.Controllers;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.Logging;
using WangYc.Core.Infrastructure.Security;
using WangYc.Services;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using StructureMap;


namespace WangYc.MVC {
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            //配置调用WebApi借口
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //加载路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //加载JS/CSS文件
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //加载控制反转
            BootStrapper.ConfigureDependencies();
            //加载Mapper
            AutoMapperBootStrapper.ConfigureAutoMapper();
            //
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(ObjectFactory.GetInstance<IApplicationSettings>());
            //
            ControllerBuilder.Current.SetControllerFactory(new WangYc.Controllers.IocControllerFactory());

            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());
             
            LoggingFactory.GetLogger().Log("Application Started");

        }

    }
}