using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WangYc.Core.Infrastructure.Domain
{
    public abstract class EntityBase<TId> {

        private List<BusinessRule> brokenRules = new List<BusinessRule>();

        public virtual TId Id { get; set; }
        public virtual TId GenerateIdPrefix() {
            return Id;
        }

        protected abstract void Validate();

        public virtual IEnumerable<BusinessRule> GetBrokenRules() {
            brokenRules.Clear();
            Validate();
            return brokenRules;
        }

        protected virtual void AddBrokenRule(BusinessRule businessRule) {
            brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity) {
            return entity != null && entity is EntityBase<TId> && this == (EntityBase<TId>)entity;
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2) {
            if ((object)entity1 == null && (object)entity2 == null) {
                return true;
            }
            if ((object)entity1 == null || (object)entity2 == null) {
                return false;
            }
            if (entity1.Id.ToString().Trim().ToUpper() == entity2.Id.ToString().Trim().ToUpper()) {
                return true;
            }
            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2) {
            return ( !( entity1 == entity2 ) );
        }

    }
}
