using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging {
    public class AddProductRequest {
        public int Id {
            get;
            set;
        }
        public string ChineseName {
            get;
            set;
        }
        public string EnglishName {
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
        public int ProductTypeId {
            get;
            set;
        }
    
    }
}
