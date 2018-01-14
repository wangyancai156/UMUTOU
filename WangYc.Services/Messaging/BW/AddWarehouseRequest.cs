using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.BW {
    public class AddWarehouseRequest {

        public int Id {
            get;
            set;
        }
        public string Name {
            get;
            set;
        }

        public string Note {
            get;
            set;
        }
        public int WarehouseTypeId {
            get;
            set;
        }
      
    }
}
