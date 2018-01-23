using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.ViewModels.BW {
    public class InOutBoundView {

        public int Id {
            get;
            set;
        }
        public int WarehouseId {
            get;
            set;
        }
        public string WarehouseName {
            get;
            set;
        }
        public string ProductId {
            get;
            set;
        }
        public string ProductChineseName {
            get;
            set;
        }
        public int Qty {
            get;
            set;
        }

        public float Price {
            get;
            set;
        }
        public string Note {
            get;
            set;
        }
        public DateTime CreateDate {
            get;
            set;
        }
        public int CreateUserId {
            get;
            set;
        }
    }

    public class InBoundView : InOutBoundView {

        public IList<OutBoundView> OutBounds {
            get;
            set;
        }
        public IEnumerable<InBoundOfShelfView> InBoundOfShelf {
            get;
            set;
        }

        public InBoundOfShelfView FirstShelf {
            get {
                return InBoundOfShelf.First();
            }
        }
        /// <summary>
        /// 库存余量
        /// </summary>
        public int CurrentQty { get; set; }
    }

    public class OutBoundView : InOutBoundView {
        public IList<OutBoundOfShelfView> OutBoundOfShelf {
            get;
            set;
        }
     
    }

   
}
