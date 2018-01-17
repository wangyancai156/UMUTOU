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


namespace WangYc.MVC
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration); //配置调用WebApi借口
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            BootStrapper.ConfigureDependencies();
            AutoMapperBootStrapper.ConfigureAutoMapper();
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(ObjectFactory.GetInstance<IApplicationSettings>());

            ControllerBuilder.Current.SetControllerFactory(new WangYc.Controllers.IocControllerFactory());
        }

        /// <summary>
        /// 在Form验证的条件下，实现Asp.net中的“模拟”功能，以支持对数据库采用“集成验证”模式，与原来Access系统访问数据库方式保持兼容
        /// 方法是：我们现在的Form验证，提交的验证凭证为域账户信息（域、用户名、密码），在验证通过后，将此信息保存在Form验证生成的Cookie
        /// 中，再次发起请求时，根据Cookie中的域账户信息生成WindowsIdentity，并将HttpContext.User设置为包含该WindowsIdentity的
        /// WindowsIPrinciple，然后实现模拟（即：newId.Impersonate()）
        /// 2015-01-07, ligsh, 设置仅POST请求才进行模拟（为了减少对AD的查询操作提高性能，这要求开发上仅POST请求才能进行数据修改操作）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args) {

            if (CurrentUserFactory.GetCurrentUser() == null) {
                System.Collections.Specialized.NameValueCollection loginInfo = GetLoginNameFrom();
                if (loginInfo != null) {
                    CurrentUserFactory.SetCurrentUser(loginInfo["DomainName"], loginInfo["UserName"]);
                }
            }

            if (args.Context.Request.HttpMethod == "POST" && System.Configuration.ConfigurationManager.AppSettings["UseTrueDomainUserToAccessDB"] == "true") {
                System.Collections.Specialized.NameValueCollection loginInfo = GetLoginNameFrom();
                if (loginInfo != null) {
                    WindowsIdentity newId = ActiveDirectoryHelper.GetWindowsIdentity(loginInfo["DomainName"], loginInfo["UserName"], loginInfo["Password"]);
                    args.User = new System.Security.Principal.WindowsPrincipal(newId);
                    newId.Impersonate();
                }
            }
        }
        private System.Collections.Specialized.NameValueCollection GetLoginNameFrom() {

            System.Collections.Specialized.NameValueCollection result = null;
            if (FormsAuthentication.CookiesSupported) {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null) {
                    try {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(
                          Request.Cookies[FormsAuthentication.FormsCookieName].Value);

                        string[] strArray = ticket.UserData.Split(new char[] { '\r', '\n', '|' }, StringSplitOptions.RemoveEmptyEntries);
                        result = new System.Collections.Specialized.NameValueCollection(3);
                        result.Add("DomainName", strArray[0]);
                        result.Add("UserName", strArray[1]);
                        result.Add("Password", strArray[2]);
                    }
                    catch (Exception e) {
                        // Decrypt method failed.
                        throw e;
                    }
                }
            }
            else {
                throw new HttpException("Cookieless Forms Authentication is not " +
                                        "supported for this application.");
            }
            return result;
        }

        public void Application_BeginRequest() {
            WangYc.Core.Infrastructure.Helpers.CultureHelper.SetUserCulture();
        }

        public void Application_Error(object sender, EventArgs args) {

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("requestpath", Request.Url.AbsoluteUri);
            data.Add("requestReferrer", Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri);

            Exception ex = Server.GetLastError();
           // logError(ex, data);
        }


        private void logError(Exception ex, System.Collections.Generic.Dictionary<string, string> data) {

            ExceptionManager exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            foreach (var key in data.Keys) {
                ex.Data.Add(key, data[key]);
            }

            if (ex.InnerException != null) {
                foreach (var key in ex.InnerException.Data.Keys) {
                    ex.Data.Add(key, ex.InnerException.Data[key]);
                }
            }
            exManager.HandleException(ex, "Global Policy");
        }


    }
}