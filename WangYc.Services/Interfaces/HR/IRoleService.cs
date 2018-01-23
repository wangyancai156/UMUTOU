using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IRoleService {

        #region 查询
        /// <summary>
        /// 获取所有的权限
        /// </summary>
        /// <returns></returns>
        IEnumerable<Role> GetRole();
        /// <summary>
        /// 获取所有的权限视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleView> GetRoleView();

        /// <summary>
        /// 根据Id获取权限视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleView GetRoleViewById(int id);

        #endregion


        #region 添加

        RoleView AddRole(int organizationid, string name, string description, string rightsIds);


        #endregion

        #region 修改

        RoleView UpdateRole(AddRoleRequest request);

        #endregion

        #region 删除

        void DeleteRole(int id);

        #endregion

    }
}
