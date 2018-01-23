using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.HR {
    public class RoleView {

        public OrganizationView Organization {
            get;
            set;
        }
        public IList<RightsView> Rights {
            get;
            set;
        }
        public string Id {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

    
    }
}
