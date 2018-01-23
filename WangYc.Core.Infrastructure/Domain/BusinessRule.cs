using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WangYc.Core.Infrastructure.Domain {
    public class BusinessRule {

        private string property;
        private string rule;

        public BusinessRule(string property, string rule) {

            this.property = property;
            this.rule = rule;
        }

        public string Property {
            get { return property; }
            set { property = value; }
        }

        public string Rule {
            get { return rule; }
            set { rule = value; }
        }


    }

}
