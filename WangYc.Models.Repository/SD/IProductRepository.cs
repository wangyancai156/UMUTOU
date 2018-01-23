using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.SD;

namespace WangYc.Models.Repository.SD {
    public interface IProductRepository : IRepository<Product, int> {
    }
}
