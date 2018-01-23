using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.BW {
    public class AddOutBoundRequest {
        public int ProductId {
            get;
            set;
        }
        public string Type {
            get;
            set;
        }
        public int WarehouseId {
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
        public string Currency {
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

        public string CreateUserId {
            get;
            set;
        }
    }
}
