using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WangYc.Core.Infrastructure.Domain
{
    public interface IIdGenerator<T, TId> where T : EntityBase<TId> {

        TId NewId(T t);
    }
}
