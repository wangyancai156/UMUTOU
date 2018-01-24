using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace WangYc.Core.Infrastructure.Account {
    public interface IAuthenticationService {

        /// <summary>
        /// 添加用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        void AddTicket(string name, string userData);

        /// <summary>
        /// 获取用户Form验证
        /// </summary>
        /// <returns></returns>
        FormsAuthenticationTicket RetrieveTicket();

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        bool Verification { get; }
    }
}
