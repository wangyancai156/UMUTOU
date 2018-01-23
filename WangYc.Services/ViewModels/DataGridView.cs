using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels {
    
    [Serializable]
    public class DataGridView {

        public string total { get; set; }
        public object rows { get; set; }
        public string footter { get; set; }
    }
}
