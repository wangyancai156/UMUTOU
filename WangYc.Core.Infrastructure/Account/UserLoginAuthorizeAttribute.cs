using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web;
using Cmmooc.Information.Component.Tools.EncryptionHelp;
using System.Web.Security;
using WangYc.Core.Infrastructure.CookieStorage;

namespace WangYc.Core.Infrastructure.Account {
    /// <summary>
    ///  登录用户身份认证过滤器
    /// </summary>
    public class UserLoginAuthorizeAttribute:AuthorizeAttribute {


        private readonly ICookieStorageService _cookieStorageService;

        public UserLoginAuthorizeAttribute( ICookieStorageService cookieStorageService) {

            this._cookieStorageService = cookieStorageService;
        }

        /// <summary>
        ///  是否登录认证
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            try {
              
                string cookieValue = this._cookieStorageService.Retrieve(FormsAuthentication.FormsCookieName);
                FormsAuthenticationTicket tickets = FormsAuthentication.Decrypt(cookieValue);
                if (tickets == null || tickets.Name == null || tickets.Expired) {
                    return false;
                }

            }
            catch {
                return false;
            }
            return true;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {

            filterContext.HttpContext.Response.Clear();
            var refs = filterContext.HttpContext.Request.Url;
            filterContext.Result = new RedirectResult("~/login/index?reurl=" + refs);
        }
    }
}

