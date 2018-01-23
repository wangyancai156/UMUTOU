using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.BW {
    public class WarehouseShelf : EntityBase<int>, IAggregateRoot {
        public WarehouseShelf() { }

        public WarehouseShelf(string name,int capacity, string note, int warehouseId) {

            this.Capacity = capacity;
            this.Note = note;
            this.WarehouseId = warehouseId;
            this.Name = name;
            this.CreateDate = DateTime.Now;
        }
        public virtual string Name {
            get;
            set;
        }
        public virtual int Capacity {
            get;
            set;
        }
        public virtual string Note {
            get;
            set;
        }
        public virtual int WarehouseId {
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
