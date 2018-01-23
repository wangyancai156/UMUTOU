using System;
using System.Web;
using System.Web.Security;

namespace WangYc.Core.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService {

        /// <summary>
        /// 保存(修改)
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public void Save(string key, string value, DateTime expires) {

            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = expires;
        }
        /// <summary>
        /// 回收（获取）
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public string Retrieve(string key) {

            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
                return cookie.Value;
            return "";
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key){

            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookie"></param>
        public void Add(HttpCookie cookie) {

            this.Remove(cookie.Name);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 添加用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        public void AddFormAuthenticationCustomeCookie(string name, string userData) {
            
            this.Add(CreateFormAuthenticationCustomeCookie(name, userData));

        }

        /// <summary>
        /// 创建用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        private HttpCookie CreateFormAuthenticationCustomeCookie(string name, string userData) {

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
