using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IRightsService {

        IEnumerable<Rights> GetRights();

        IEnumerable<Rights> GetRightsByIdList(string[] rightsIdList);

        IEnumerable<RightsView> GetRightsView();

        IEnumerable<DataTreeView> GetRightsTreeView();

        IEnumerable<RightsView> GetRightsView(int roleid);

        RightsView AddRightsChild(int id, string name,string url, string description, bool isshow);
        RightsView UpdateRights(int id, string name,string url, string description, bool isshow);
        void DeleteRights(int id);

    }
}
