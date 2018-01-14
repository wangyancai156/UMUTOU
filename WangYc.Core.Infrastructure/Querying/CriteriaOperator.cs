using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WangYc.Core.Infrastructure.Querying
{
    public enum CriteriaOperator {

        Equal,
        NotEqual,
        LesserThanOrEqual,
        GreaterThanOrEqual,
        NotApplicable,
        InOfInt32,
        NotInOfInt32,
        InOfString,
        NotInOfString,
        Like,
        IsNull,
        IsNotNull
    }
}
