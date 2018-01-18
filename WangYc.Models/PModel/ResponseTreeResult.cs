using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Models.PModel
{
    /// <summary>
    ///  树形下拉框的结果对象
    /// </summary>
    public class ResponseTreeResult
    {

        /// <summary>
        /// 节点的 id，它对于加载远程数据很重要。
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 要显示的节点文本。
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 节点状态，'open' 或 'closed'，默认是 'open'。当设置为 'closed' 时，该节点有子节点，并且将从远程站点加载它们。
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ResponseTreeResult> children { get; set; }
    }
}
