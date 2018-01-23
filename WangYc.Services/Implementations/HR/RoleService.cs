using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Mapping.HR;
using WangYc.Services.Messaging.HR;

namespace WangYc.Services.Implementations.HR {
    public class RoleService : IRoleService {

        private readonly IRoleRepository _roleRepository;
        private readonly IRightsService _rightsService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _uow;

        public RoleService(IRoleRepository roleRepository, IRightsService rightsService, IOrganizationRepository organizationRepository, IUnitOfWork uow) {
            
            this._roleRepository = roleRepository;
            this._rightsService = rightsService;
            this._organizationRepository = organizationRepository;
            this._uow = uow;
        }

        #region 查询

        /// <summary>
        /// 获取所有的权限
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetRole() {
            IEnumerable<Role> model = _roleRepository.FindAll();
            return model;
        }
        /// <summary>
        /// 获取所有的权限视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleView> GetRoleView() {
            IEnumerable<Role> role = _roleRepository.FindAll();
            return role.ConvertToRoleView();
        }
        /// <summary>
        /// 根据Id获取权限视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleView GetRoleViewById(int id) {
            Role role = _roleRepository.FindBy(id);
            return role.ConvertToRoleView();
        }

        #endregion


        #region 添加

        public RoleView AddRole(int organizationid, string name, string description, string rightsIds) {

            string[] rightsIdList = rightsIds.Split('|');
            Organization orgmodel = this._organizationRepository.FindBy(organizationid);
            if (orgmodel == null) {
                throw new EntityIsInvalidException<string>(organizationid.ToString());
            }

            Role model = new Role(orgmodel, name, description);
            IEnumerable<Rights> rightslList = this._rightsService.GetRightsByIdList(rightsIdList);
            model.AddRights(rightslList);

            this._roleRepository.Add(model);
            this._uow.Commit();
            return model.ConvertToRoleView();
        }


        #endregion

        #region 修改

        public RoleView UpdateRole(AddRoleRequest request) {

            Role model = this._roleRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(model.ToString());
            }

            model.UpdateRole(request.Name, request.Description);
            this._uow.Commit();
            return model.ConvertToRoleView();
        }

        #endregion

        #region 删除

        public void DeleteRole(int id) {

            Role model = this._roleRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(model.ToString());
            }
            this._roleRepository.Remove(model);
            this._uow.Commit();
        }
        #endregion


    }
}