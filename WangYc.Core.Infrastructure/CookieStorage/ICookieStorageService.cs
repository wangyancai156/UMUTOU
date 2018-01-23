using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WangYc.Core.Infrastructure.CookieStorage
{
    public interface ICookieStorageService {

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        void Save(string key, string value, DateTime expires);

        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns></returns>
        string Retrieve(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookie"></param>
        void Add(HttpCookie cookie);
 
    }
}
