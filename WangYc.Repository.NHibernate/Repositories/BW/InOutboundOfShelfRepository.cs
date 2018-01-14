using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;

namespace WangYc.Repository.NHibernate.Repositories.BW {
  
    public class InOutBoundOfShelfRepository : Repository<InOutBoundOfShelf, int>, IInOutBoundOfShelfRepository {
        public InOutBoundOfShelfRepository(IUnitOfWork uow)
            : base(uow) { }
    }

    public class InBoundOfShelfRepository : Repository<InBoundOfShelf, int>, IInBoundOfShelfRepository {

        public InBoundOfShelfRepository(IUnitOfWork uow)
            : base(uow) {
        }
    }

    public class OutBoundOfShelfRepository : Repository<OutBoundOfShelf, int>, IOutBoundOfShelfRepository {

        public OutBoundOfShelfRepository(IUnitOfWork uow)
            : base(uow) {
        }
    }
}

