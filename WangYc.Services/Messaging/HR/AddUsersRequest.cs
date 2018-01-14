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


        string id;
        public string Id {
            get { return id; }
            set { id = value; }
        }

        string username;
        public string UserName {
            get { return username; }
            set { username = value; }
        }

        string userpwd;
        public string UserPwd {
            get { return userpwd; }
            set { userpwd = value; }
        }
    }
}
