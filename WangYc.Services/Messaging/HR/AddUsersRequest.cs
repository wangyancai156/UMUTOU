using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.HR {
    public class AddUsersRequest {


        int organizationid;

        public int Organizationid {
            get { return organizationid; }
            set { organizationid = value; }
        }

        string telephone;
        public string Telephone {
            get { return telephone; }
            set { telephone = value; }
        }

        /// <summary>
        ///  用户编号
        /// </summary>
        string id;
        public string Id {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        ///  用户姓名（登录账号）
        /// </summary>
        string username;
        public string UserName {
            get { return username; }
            set { username = value; }
        }
        /// <summary>
        ///  密码
        /// </summary>
        string userpwd;
        public string UserPwd {
            get { return userpwd; }
            set { userpwd = value; }
        }
        /// <summary>
        ///  最后一次登录时间
        /// </summary>
        DateTime lastsigntime;
        public DateTime LastSignTime
        {
            get { return lastsigntime; }
            set { lastsigntime = value; }
        }
    }
}
