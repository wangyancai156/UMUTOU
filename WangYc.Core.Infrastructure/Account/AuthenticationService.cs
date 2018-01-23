using System;
using System.Web;
using System.Web.Security;
using WangYc.Core.Infrastructure.CookieStorage;

namespace WangYc.Core.Infrastructure.Account {
    public class AuthenticationService: IAuthenticationService {

        ICookieStorageService _cookieStorageService;
        public AuthenticationService(ICookieStorageService cookieStorageService) {

            this._cookieStorageService = cookieStorageService;
        }

        /// <summary>
        /// 添加用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        public void AddFormAuthenticationCustomeCookie(string name, string userData) {

            this._cookieStorageService.Add(CreateFormAuthenticationCustomeCookie(name, userData));
        }

        /// <summary>
        /// 创建用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        public HttpCookie CreateFormAuthenticationCustomeCookie(string name, string userData) {

            // 1.创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, name, DateTime.Now, DateTime.Now.AddHours(4), true, userData);

            // 2.加密Ticket，变成一个加密的字符串。
            string cookieValue = FormsAuthentication.Encrypt(ticket);

            //解密Ticket
            FormsAuthenticationTicket tickets = FormsAuthentication.Decrypt(cookieValue);

            // 3.根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = DateTime.Now.AddHours(4);

            return cookie;
        }
    }
}
