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
    }
}
