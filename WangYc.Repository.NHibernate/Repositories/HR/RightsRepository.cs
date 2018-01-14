using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Repository.NHibernate.Repositories;
using WangYc.Core.Infrastructure.UnitOfWork;
 
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
using WangYc.Core.Infrastructure.Querying;
using NHibernate.Criterion;
using NHibernate.Type;
using NHibernate;

namespace WangYc.Repository.NHibernate.Repositories.HR {
    public class RightsRepository : Repository<Rights, int>, IRightsRepository {
        public RightsRepository(WangYc.Core.Infrastructure.UnitOfWork.IUnitOfWork uow)
            : base(uow) { }

        public override QueryTranslator CreateQueryTranslator(Query query) {
            return new RightsQuery(query);
        }
        private class RightsQuery : QueryTranslator {
            public RightsQuery(Query query)
                : base(query) {
            }

            private string[] indirectProperties = new string[] { "fndbyroleid" };

            public override string[] IndirectProperties {
                get { return indirectProperties; }
            }
            public override ICriterion GenerateSqlCriterion(Criterion criterion) {

                ICriterion result;
                Object[] args = new Object[] { criterion.Value, criterion.Value };
                IType[] types = new IType[] { NHibernateUtil.String, NHibernateUtil.String };

                switch (criterion.PropertyName.ToLower()) {
                    case "fndbyroleid":
                        result = Expression.Sql("{alias}.Id in (select RightsId from wangyc.dbo.RoleRights where RoleId=?)", args[0], types[0]);
                        break;
                    default:
                        throw new ApplicationException("No property defined");
                }
                return result;
            }

        }
    }
}
