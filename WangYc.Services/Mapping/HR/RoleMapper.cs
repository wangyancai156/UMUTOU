using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Mapping.HR {
    public static class RoleMapper {

        public static RoleView ConvertToRoleView(this Role model) {

            return Mapper.Map<Role, RoleView>(model);
        }

        public static IEnumerable<RoleView> ConvertToRoleView(this IEnumerable<Role> model) {
            return Mapper.Map<IEnumerable<Role>, IEnumerable<RoleView>>(model);
        }
    }
}
