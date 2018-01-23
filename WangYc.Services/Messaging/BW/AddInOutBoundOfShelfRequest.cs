using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.BW {
    public class AddInOutBoundOfShelfRequest {
        public int Id {
            get;
            set;
        }
        public string InOutBoundId {
            get;
            set;
        }
        public string Type {
            get;
            set;
        }
        public int WarehouseShelfId {
            get;
            set;
        }
        public int Qty {
            get;
            set;
        }
        public string Note {
            get;
            set;
        }
        public int ParentId {
            get;
            set;
        }
        public DateTime CreateDate {
            get;
            set;
        }
        public string CreateUserId {
            get;
            set;
        }
    }
}
