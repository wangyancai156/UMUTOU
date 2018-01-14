using System;
using System.Web;

namespace WangYc.Core.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService {

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public void Save(string key, string value, DateTime expires) {

            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = expires;
        }
        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public string Retrieve(string key) {

            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
                return cookie.Value;
            return "";
        }

        public void Remove(string key){

            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
