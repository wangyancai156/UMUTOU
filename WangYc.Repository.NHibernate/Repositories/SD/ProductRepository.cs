using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.SD;
using WangYc.Models.SD;

namespace WangYc.Repository.NHibernate.Repositories.SD {
    public class ProductRepository : Repository<Product, int>, IProductRepository {
        public ProductRepository(IUnitOfWork uow)
            : base(uow) { }
    }

}
