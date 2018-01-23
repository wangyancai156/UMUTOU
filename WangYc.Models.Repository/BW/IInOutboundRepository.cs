using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.BW;

namespace WangYc.Models.Repository.BW {
    public interface IInOutBoundRepository : IRepository<InOutBound, int> {
    }

    public interface IInBoundRepository : IRepository<InBound, int> {
      
    }

    public interface IOutBoundRepository : IRepository<OutBound, int> {

    }
}
