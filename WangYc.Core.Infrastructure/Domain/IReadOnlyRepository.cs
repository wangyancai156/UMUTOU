using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WangYc.Core.Infrastructure.Querying;

namespace WangYc.Core.Infrastructure.Domain
{

    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot {

        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Query query);

        int CountAll();
        int CountBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
    }

}
