using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.ViewModels;

namespace WangYc.Services.Mapping.HR
{
    public static class RightsMapper
    {
        public static RightsView ConvertToRightsView(this Rights permission)
        {

            return Mapper.Map<Rights, RightsView>(permission);
        }

        public static IEnumerable<RightsView> ConvertToRightsView(this IEnumerable<Rights> permissions)
        {
            return Mapper.Map<IEnumerable<Rights>, IEnumerable<RightsView>>(permissions);
        }


        public static DataTreeView ConvertToDataTreeView(this Rights rights) {

            return Mapper.Map<Rights, DataTreeView>(rights);
        }

        public static IEnumerable<DataTreeView> ConvertToDataTreeView(this IEnumerable<Rights> rights) {
            return Mapper.Map<IEnumerable<Rights>, IEnumerable<DataTreeView>>(rights);
        }
    }
}
