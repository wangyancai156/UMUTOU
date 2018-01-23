using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.BW {
    public class InOutBoundOfShelfView {

        public int Id {
            get;
            set;
        }
        public   string InOutBoundId {
            get;
            set;
        }
        public int WarehouseShelfId {
            get;
            set;
        }
        public string WarehouseShelfName {
            get;
            set;
        }
        public   int Qty {
            get;
            set;
        }
        public   string Note {
            get;
            set;
        }
      
        public   DateTime CreateDate {
            get;
            set;
        }
        public int CreateUserId {
            get;
            set;
        }
    }

    public class InBoundOfShelfView : InOutBoundOfShelfView {

        /// <summary>
        /// 库存余量
        /// </summary>
        public int CurrentQty { get; set; }
    }

    public class OutBoundOfShelfView : InOutBoundOfShelfView {

    }

   
}
