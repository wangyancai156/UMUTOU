using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR
{
    public interface IUsersService
    {
        /// <summary>
        /// IEnumerable与IList等其它类型的集合的区别？？
        /// </summary>
        IEnumerable<Users> GetUsers();

        IEnumerable<UsersView> GetUsersView();

        UsersView FindUsersBy(string userid);
        /// <summary>
        ///  用户登录时查询
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        UsersView FindUsersBy(string username, string pass);

        Users FindBy(string userId);

        void DeleteUsers(string userid);

        void InsertUsers(AddUsersRequest user);

        void UpdateUsers(AddUsersRequest request);
        /// <summary>
        ///  更新最后登录时间
        /// </summary>
        /// <param name="userId">用户编号</param>
        void UpdateLastLoginTime(string userId);
    }
}
