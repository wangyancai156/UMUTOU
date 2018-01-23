using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.BW {
    public class AddWarehouseShelfRequest {

        public virtual int Id {
            get;
            set;
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
    }
}
