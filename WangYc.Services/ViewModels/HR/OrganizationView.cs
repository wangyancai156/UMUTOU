using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.HR {
    public class OrganizationView {

        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descriptin { get; set; }
        public int Level { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createdate;
        public string CreateDate { 
            get { return createdate.ToString("yyyy-MM-dd HH:mm:ss"); } 
            set { createdate = Convert.ToDateTime(value); }
        }

        /// <summary>
        /// 子节点
        /// </summary>
        public IEnumerable<OrganizationView> Child { get; set; }

        public int ParentId { get; set; }
    }
}
