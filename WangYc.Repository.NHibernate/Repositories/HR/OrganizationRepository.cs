using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Repository.NHibernate.Repositories;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models;
using WangYc.Models.Repository;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;

namespace WangYc.Repository.NHibernate.Repositories.HR {

    public class OrganizationRepository : Repository<Organization, int>, IOrganizationRepository {
        public OrganizationRepository(WangYc.Core.Infrastructure.UnitOfWork.IUnitOfWork uow)
            : base(uow) { }
    }
}
