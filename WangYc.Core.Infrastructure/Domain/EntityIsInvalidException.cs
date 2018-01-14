using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WangYc.Core.Infrastructure.Domain
{
    public class EntityIsInvalidException<TId> : Exception {

        public EntityIsInvalidException(TId entityId)
            : base(entityId.ToString() + " not exists.") {
        }
    }
}
