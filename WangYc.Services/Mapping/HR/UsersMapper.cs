using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Mapping.HR {
    public static class UsersMapper {

        public static UsersView ConvertToUsersView(this Users users) {

            return Mapper.Map<Users, UsersView>(users);
        }

        public static IEnumerable<UsersView> ConvertToUsersView(this IEnumerable<Users> users) {

            return Mapper.Map<IEnumerable<Users>, IEnumerable<UsersView>>(users);
        }
    }
}
