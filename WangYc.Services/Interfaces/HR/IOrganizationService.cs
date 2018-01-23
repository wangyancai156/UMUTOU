using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IOrganizationService {

        IEnumerable<DataTreeView> GetOrganizationTreeView();

        IEnumerable<OrganizationView> GetOrganization();

        OrganizationView AddOrganizationChild(int id, string name, string description);

        OrganizationView UpdateOrganization(int id, string name, string description);

        void DeleteOrganization(int id);
    }
}
