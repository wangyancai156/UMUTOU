using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IUsersService {
        /// <summary>
        /// IEnumerable与IList等其它类型的集合的区别？？
        /// </summary>
        IEnumerable<Users> GetUsers();

        IEnumerable<UsersView> GetUsersView();

        UsersView FindUsersBy(string userid);
        Users FindBy(string userId);

        void DeleteUsers(string userid);

        void InsertUsers(AddUsersRequest user);

        void UpdateUsers(AddUsersRequest request);
    }
}
