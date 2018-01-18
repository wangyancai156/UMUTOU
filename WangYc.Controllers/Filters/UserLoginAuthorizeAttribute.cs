using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using WangYc.Core.Common;
using System.Web;
using Cmmooc.Information.Component.Tools.EncryptionHelp;

namespace WangYc.Controllers.Filters
{
    /// <summary>
    ///  登录用户身份认证过滤器
    /// </summary>
    public class UserLoginAuthorizeAttribute: AuthorizeAttribute
    {

        /// <summary>
        ///  是否登录认证
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var ucookie = httpContext.Request.Cookies[CookieKeyDefine.LoginUserInfo];
            if (ucookie == null || ucookie.Values.Count == 0) return false;
            if (ucookie[CookieKeyDefine.LoginUserId] == null || string.IsNullOrWhiteSpace(ucookie[CookieKeyDefine.LoginUserId]))
            {
                return false;
            }
            var userId = ucookie[CookieKeyDefine.LoginUserId];
            try
            {
                userId = DESEncrypt.Decrypt(userId, CookieKeyDefine.WebEncryptionKey, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // TODO：使用log4net记录错误日志
                return false;
            }
            return true;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Clear();
            var refs = filterContext.HttpContext.Request.Url;
            filterContext.Result = new RedirectResult("~/login/index?reurl=" + refs);
        }
    }
}
