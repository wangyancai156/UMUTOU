using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using WangYc.Controllers.Filters;
using WangYc.Services.ViewModels.HR;
using WangYc.Core.Common;
using Cmmooc.Information.Component.Tools.EncryptionHelp;

namespace WangYc.Controllers.Controllers
{
    /// <summary>
    ///  用户登录后的控制器类
    /// </summary>
    [UserLoginAuthorizeAttribute]
    public class BaseLoginController : WebAppController
    {

        /// <summary>
        ///  从cookie中获取登录用户信息
        /// </summary>
        /// <returns></returns>
        protected UsersView GetLoginUserInfo()
        {
            var user = new UsersView();
            var ucookie = HttpContext.Request.Cookies[CookieKeyDefine.LoginUserInfo];
            if (ucookie == null || ucookie.Values.Count == 0) return user;
            var userId = System.Web.HttpContext.Current.Server.UrlDecode(ucookie[CookieKeyDefine.LoginUserId]);
            userId = DESEncrypt.Decrypt(userId, CookieKeyDefine.WebEncryptionKey, Encoding.UTF8);
            user.Id = userId;
            user.UserName = System.Web.HttpContext.Current.Server.UrlDecode(ucookie[CookieKeyDefine.LoginUserName]);

            return user;
        }
    }
}
