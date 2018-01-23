using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Core.Infrastructure.Account {
    public interface IAuthenticationService {

        /// <summary>
        /// 添加用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        void AddFormAuthenticationCustomeCookie(string name, string userData);
    }
}
