using NHibernate;
using NHibernate.Criterion;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;

namespace WangYc.Repository.NHibernate.Repositories.BW {
    public class InOutBoundRepository : Repository<InOutBound, int>, IInOutBoundRepository {
        public InOutBoundRepository(IUnitOfWork uow)
            : base(uow) { }
    }

    public class InBoundRepository : Repository<InBound, int>, IInBoundRepository {

        public InBoundRepository(IUnitOfWork uow)
            : base(uow) {
        }

        private class InBoundQuery : QueryTranslator {
            public InBoundQuery(Query query)
                : base(query) {
            }

            private string[] indirectProperties = new string[] { "CurrentQty" };

            public override string[] IndirectProperties {
                get { return indirectProperties; }
            }

            public override ICriterion GenerateSqlCriterion(Criterion criterion) {

                ICriterion result;
                Object[] args = new Object[] { criterion.Value, criterion.Value };
                IType[] types = new IType[] { NHibernateUtil.String, NHibernateUtil.String };

                switch (criterion.PropertyName.ToLower()) {
                    case "CurrentQty":
                        result = Expression.Sql(@" {alias}.");
                        break;
                    default:
                        throw new ApplicationException("No property defined");
                }
                return result;
            }
        }
    }

    public class OutBoundRepository : Repository<OutBound, int>, IOutBoundRepository {

        public OutBoundRepository(IUnitOfWork uow)
            : base(uow) {
        }
    }
}
