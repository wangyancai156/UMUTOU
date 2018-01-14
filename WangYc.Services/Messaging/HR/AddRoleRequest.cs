using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.HR {
    public class AddRoleRequest {

        int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        int organizationid;

        public int Organizationid {
            get { return organizationid; }
            set { organizationid = value; }
        }

        string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        string description;
        public string Description {
            get { return description; }
            set { description = value; }
        }

    }
}
