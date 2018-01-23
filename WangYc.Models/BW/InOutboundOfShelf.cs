using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.BW {

    public abstract class InOutBoundOfShelf : EntityBase<int>, IAggregateRoot {

        public InOutBoundOfShelf() { }

        public virtual WarehouseShelf WarehouseShelf {
            get;
            set;
        }
        public virtual int Qty {
            get;
            set;
        }
        public virtual int CurrentQty {
            get;
            set;
        }
        public virtual string Note {
            get;
            set;
        }
        public virtual int ParentId {
            get;
            set;
        }
        public virtual DateTime CreateDate {
            get;
            set;
        }
        public virtual int CreateUserId {
            get;
            set;
        }
        protected override void Validate() {
            throw new NotImplementedException();
        }

    }

    public class InBoundOfShelf : InOutBoundOfShelf {

        public InBoundOfShelf() { }
        public InBoundOfShelf(InBound inBound, WarehouseShelf warehouseShelf, int qty, string note, int createUserId) {

            this.InBound = inBound;
            this.WarehouseShelf = warehouseShelf;
            this.Qty = qty;
            this.Note = note;
            this.CreateUserId = createUserId;
            this.CreateDate = DateTime.Now;
        }

        public virtual InBound InBound {
            get;
            set;
        }

        public virtual IList<OutBoundOfShelf> OutBoundOfShelfs {
            get;             
            set;
        }

        //添加货架出库记录
        public virtual void AddOutBoundOfShelf(OutBound outBound, int qty, string note, int createUserId) {

            if (this.OutBoundOfShelfs == null) {
                this.OutBoundOfShelfs = new List<OutBoundOfShelf>();
            }
            OutBoundOfShelf one = new OutBoundOfShelf(this, outBound, qty, note, createUserId);
            this.OutBoundOfShelfs.Add(one);

        }

        public virtual void RefreshCurrentQty() {
       
            int outqtysum = 0;
            if (this.OutBoundOfShelfs != null) {
                outqtysum = this.OutBoundOfShelfs.Sum(e => e.Qty);
            }
            this.CurrentQty = this.Qty - outqtysum;
        }
    }

    public class OutBoundOfShelf : InOutBoundOfShelf {
        public OutBoundOfShelf() { }
        public OutBoundOfShelf(InBoundOfShelf inBoundOfShelf,OutBound outBound, int qty, string note, int createUserId) {

            this.OutBound = outBound;
            this.InBoundOfShelf = inBoundOfShelf;
            this.WarehouseShelf = inBoundOfShelf.WarehouseShelf;
            this.Qty = qty;
            this.Note = note;
            this.CreateUserId = createUserId;
            this.CreateDate = DateTime.Now;
        }

        public virtual OutBound OutBound {
            get;
            set;
        }
        public virtual InBoundOfShelf InBoundOfShelf {
            get;
            set;
        }

        

    }
}
