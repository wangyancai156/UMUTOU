using StructureMap;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.Logging;
using WangYc.Services;


namespace WangYc.MVC {
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            //区域
            AreaRegistration.RegisterAllAreas();

            //配置调用WebApi借口
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //过滤器
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