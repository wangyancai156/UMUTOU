using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmmooc.Information.Component.Tools.WebHelp;
using Cmmooc.Information.Component.Tools.EncryptionHelp;
using WangYc.Services.ViewModels.HR;
using WangYc.Core.Common;
using System.Web;

namespace WangYc.Controllers.Controllers
{
    public class WebAppController : BaseController
    {

        /// <summary>
        ///  将用户登录信息保存到cookie中
        /// </summary>
        /// <param name="user"></param>
        protected void SaveLoginCookie(UsersView user)
        {
            Response.Cookies.Remove(CookieKeyDefine.LoginUserInfo);
            var ucookie = new HttpCookie(CookieKeyDefine.LoginUserInfo);
            ucookie.HttpOnly = false;
            // 为安全考虑，对USERID进行 DES 加密
            var userId = DESEncrypt.Encrypt(user.Id, CookieKeyDefine.WebEncryptionKey, Encoding.UTF8);
            ucookie.Values.Add(CookieKeyDefine.LoginUserId, userId);
            ucookie.Values.Add(CookieKeyDefine.LoginUserName, Server.UrlEncode(user.UserName));
            ucookie.Path = "/";
            ucookie.Domain = "";
#if (!DEBUG)
                ucookie.Domain = "umutou.com";
#endif
            ucookie.Expires.AddDays(1);
            Response.SetCookie(ucookie);
        }

        /// <summary>
        ///  退出登录
        /// </summary>
        protected void RemoveLoginUserCookie()
        {
            var ucookie = new HttpCookie(CookieKeyDefine.LoginUserInfo);
            if (ucookie == null) return;
            ucookie.Expires = DateTime.Now.AddDays(-1);
#if (!DEBUG)
                ucookie.Domain = "umutou.com";
#endif
            Response.Cookies.Set(ucookie);//清除用户 cookie
        }
    }
}
