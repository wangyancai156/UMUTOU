using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.BW;

namespace WangYc.Models.Repository.BW {
    public interface IWarehouseRepository : IRepository<Warehouse, int> {
    }
}
