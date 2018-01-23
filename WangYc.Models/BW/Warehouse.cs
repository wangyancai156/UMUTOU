using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.BW {
    public class Warehouse : EntityBase<int>, IAggregateRoot {

        #region 基本信息
        public Warehouse() { }

        public Warehouse(string name, string note, int warehouseTypeId) {

            this.Name = name;
            this.Note = note;
            this.WarehouseTypeId = warehouseTypeId;
            this.CreateDate = DateTime.Now;
            this.State = true;
        }

        public virtual string Name {
            get;
            set;
        }
        
        public virtual string Note {
            get;
            set;
        }
        public virtual int WarehouseTypeId {
            get;
            set;
        }
        public virtual bool State {
            get;
            set;
        }
   
        public virtual DateTime CreateDate {
            get;
            set;
        }


        public virtual IList<WarehouseShelf> Shelf {
            get;
            set;
        }
        protected override void Validate() {
            throw new NotImplementedException();
        }

        #endregion


        #region 货架

        /// <summary>
        /// 添加货架
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="note"></param>
        public virtual void AddWarehouseShelf(string name, int capacity, string note) {

            if (this.Shelf == null) {
                Shelf = new List<WarehouseShelf> { };
            }

            WarehouseShelf model = new WarehouseShelf(name, capacity, note, this.Id);
            this.Shelf.Add(model);
        }
        /// <summary>
        /// 修改货架
        /// </summary>
        /// <param name="shelfId"></param>
        public virtual void UpdateWarehouseShelf(int shelfId,string name, int capacity, string note) {

            foreach (WarehouseShelf item in this.Shelf) {
                if (item.Id == shelfId) {
                    item.Name = name;
                    item.Capacity = capacity;
                    item.Note = note;
                    break;
                }
            }
        }
        /// <summary>
        /// 删除货架
        /// </summary>
        /// <param name="shelfId"></param>
        public virtual void RemoveWarehouseShelf(int shelfId) {

            foreach (WarehouseShelf item in this.Shelf) {
                if (item.Id == shelfId) {
                    this.Shelf.Remove(item);
                    break;
                }
            }
        }

        #endregion 
    }
}
