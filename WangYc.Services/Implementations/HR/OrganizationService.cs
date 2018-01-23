using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;

using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
 
using WangYc.Services.Mapping.HR;
using WangYc.Services.Interfaces.HR;

using WangYc.Services.ViewModels.HR;
using WangYc.Services.ViewModels;
using WangYc.Core.Infrastructure.Domain;


namespace WangYc.Services.Implementations.HR {
    public class OrganizationService : IOrganizationService {

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _uow;

        public OrganizationService(IOrganizationRepository organizationRepository, IUnitOfWork uow)
        {
            this._organizationRepository = organizationRepository;
            this._uow = uow;
           
        }

        #region 查询
        public IEnumerable<DataTreeView> GetOrganizationTreeView() {
            
            Query query = new Query();
            query.Add(Criterion.Create<Organization>(c => c.Parent, null, CriteriaOperator.IsNull));
            return this._organizationRepository.FindBy(query).ConvertToDataTreeView();
        }

        public IEnumerable<OrganizationView> GetOrganization() {

            Query query = new Query();
            query.Add(Criterion.Create<Organization>(c => c.Parent, null, CriteriaOperator.IsNull));
            return this._organizationRepository.FindAll().ConvertToOrganizationView();
        }
        #endregion


        #region 添加

        public OrganizationView AddOrganizationChild(int id, string name, string description) {

            Organization organization = this._organizationRepository.FindBy(id);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }

            Organization result = organization.AddChild(name, description);
            this._uow.Commit();
            return result.ConvertToOrganizationView();
        }


        #endregion

        #region 修改

        public OrganizationView UpdateOrganization(int id, string name, string description) {

            Organization organization = this._organizationRepository.FindBy(id);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }

            organization.UpdateOrganization(name, description);
            this._uow.Commit();
            return organization.ConvertToOrganizationView();
        }

        #endregion

        #region 删除

        public void DeleteOrganization(int id) { 

            Organization organization = this._organizationRepository.FindBy(id);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }
            this._organizationRepository.Remove(organization);
            this._uow.Commit();
        }
        #endregion
    }
}
