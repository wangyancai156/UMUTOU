using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace WangYc.Core.Infrastructure.Querying
{

    public class Criterion {

        private string propertyName;
        private object value;
        private CriteriaOperator criteriaOperator;

        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator) {

            this.propertyName = propertyName;
            this.value = value;
            this.criteriaOperator = criteriaOperator;
        }

        public string PropertyName {
            get { return this.propertyName; }
        }

        public object Value {
            get { return this.value; }
        }

        public CriteriaOperator CriteriaOperator {
            get { return this.criteriaOperator; }
        }

        public static Criterion Create<T>(Expression<Func<T, object>> expression,
            object value, CriteriaOperator criteriaOperator) {

            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator);
            return myCriterion;
        }

        private ICollection values;

        public ICollection Values
        {
            get { return this.values; }
        }

        public Criterion(string propertyName, ICollection values, CriteriaOperator criteriaOperator)
        {
            this.propertyName = propertyName;
            this.values = values;
            this.criteriaOperator = criteriaOperator;
        }

        public static Criterion Create<T>(Expression<Func<T, object>> expression, ICollection values, CriteriaOperator criteriaOperator)
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, values, criteriaOperator);
            return myCriterion;
        }
    }
}
