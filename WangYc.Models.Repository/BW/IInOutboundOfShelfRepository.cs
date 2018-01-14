using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.BW;

namespace WangYc.Models.Repository.BW {

    public interface IInOutBoundOfShelfRepository : IRepository<InOutBoundOfShelf, int> {
    }

    public interface IInBoundOfShelfRepository : IRepository<InBoundOfShelf, int> {

    }

    public interface IOutBoundOfShelfRepository : IRepository<OutBoundOfShelf, int> {

    }
}
