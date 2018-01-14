using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using WangYc.Models.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Mapping.HR {
    public static class OrganizationMapper {

        public static OrganizationView ConvertToOrganizationView(this Organization organization) {

            return Mapper.Map<Organization, OrganizationView>(organization);
        }

        public static IEnumerable<OrganizationView> ConvertToOrganizationView(this IEnumerable<Organization> organization) {
            return Mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationView>>(organization);
        }

        public static DataTreeView ConvertToDataTreeView(this Organization organization) {

            return Mapper.Map<Organization, DataTreeView>(organization);
        }

        public static IEnumerable<DataTreeView> ConvertToDataTreeView(this IEnumerable<Organization> organization) {
            return Mapper.Map<IEnumerable<Organization>, IEnumerable<DataTreeView>>(organization);
        }

    }
}
