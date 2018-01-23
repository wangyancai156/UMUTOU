using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.SD {
    public class Product : EntityBase<int>, IAggregateRoot {

        public Product() { }

        public Product(string chineseName, string englishName, float price
                , string currency, string note, int priductTypeId
        ) {

            this.ChineseName = chineseName;
            this.EnglishName = englishName;
            this.Price = price;
            this.Currency = currency;
            this.ProductTypeId = priductTypeId;
            this.Note = note;
            this.CreateDate = DateTime.Now;

        }

        public virtual string ChineseName {
            get;
            set;
        }
        public virtual string EnglishName {
            get;
            set;
        }
        public virtual float Price {
            get;
            set;
        }
        public virtual string Currency {
            get;
            set;
        }
        public virtual string Note {
            get;
            set;
        }
        public virtual int ProductTypeId {
            get;
            set;
        }
        public virtual DateTime CreateDate {
            get;
            set;
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}
