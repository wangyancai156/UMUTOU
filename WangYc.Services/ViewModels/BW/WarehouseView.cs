using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.BW {
    public class WarehouseView {
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
        public bool State {
            get;
            set;
        }
        public DateTime CreateDate {
            get;
            set;
        }

        public IList<WarehouseShelfView> Shelf {
            get;
            set;
        }
    }
}
