using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels {
    public class DataTreeView {
        public string id { get; set; }
        public string text { get; set; }

        public string ParentId { get; set; }

        public IEnumerable<DataTreeView> nodes { get; set; }

    }
}
