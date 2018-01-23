using System.Collections.Generic;

using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;

using WangYc.Models.HR;
using WangYc.Models.Repository.HR;

using WangYc.Repository.NHibernate.Repositories.HR;
using WangYc.Repository.NHibernate;

using WangYc.Services.Mapping.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.ViewModels;

namespace WangYc.Services.Implementations.HR {
    public class RightsService : IRightsService {
        private readonly IRightsRepository _rightsRepository;
        private readonly IUnitOfWork _uow;

        public RightsService(IRightsRepository rightsRepository, IUnitOfWork uow) {
            this._rightsRepository = rightsRepository;
            this._uow = uow;

        }

        #region 查询
        public IEnumerable<Rights> GetRights() {
            
            IEnumerable<Rights> rights = _rightsRepository.FindAll();
            return rights;
        }
        public IEnumerable<Rights> GetRightsByIdList(string[] rightsIdList) {

            Query query = new Query();
            if (rightsIdList != null)
                query.Add(Criterion.Create<Rights>(p => p.Id, rightsIdList, CriteriaOperator.InOfInt32));

            IEnumerable<Rights> rights = this._rightsRepository.FindBy(query);
            return rights;
        }

        public IEnumerable<RightsView> GetRightsView() {
            IEnumerable<Rights> rights = _rightsRepository.FindAll();
            return rights.ConvertToRightsView();
        }
        public IEnumerable<DataTreeView> GetRightsTreeView() {

            Query query = new Query();
            query.Add(Criterion.Create<Rights>(c => c.Parent, null, CriteriaOperator.IsNull));
            IEnumerable<Rights> rights = _rightsRepository.FindBy(query);
            return rights.ConvertToDataTreeView();
        }

        public IEnumerable<RightsView> GetRightsView(int roleid ) {

            Query query = new Query();
            query.Add(new Criterion("fndbyroleid", roleid, CriteriaOperator.Equal));
            IEnumerable<Rights> rights = _rightsRepository.FindBy(query);
            return rights.ConvertToRightsView();
        }

      
        #endregion

        #region 添加

        public RightsView AddRightsChild(int id, string name,string url, string description, bool isshow) {

            Rights rights = this._rightsRepository.FindBy(id);
            if (rights == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }

            Rights result = rights.AddChild(name, url, description, isshow);
            this._uow.Commit();
            return result.ConvertToRightsView();
        }


        #endregion

        #region 修改

        public RightsView UpdateRights(int id, string name,string url, string description, bool isshow) {

            Rights rights = this._rightsRepository.FindBy(id);
            if (rights == null) {
                throw new EntityIsInvalidException<string>(rights.ToString());
            }

            rights.UpdateRights(name, url, description, isshow);
            this._uow.Commit();
            return rights.ConvertToRightsView();
        }

        #endregion

        #region 删除

        public void DeleteRights(int id) {

            Rights rights = this._rightsRepository.FindBy(id);
            if (rights == null) {
                throw new EntityIsInvalidException<string>(rights.ToString());
            }
            this._rightsRepository.Remove(rights);
            this._uow.Commit();
        }
        #endregion

    }
}
