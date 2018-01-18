using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Models.PModel
{
    /// <summary>
    /// easy ui 分页对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResponse<T> where T : new()
    {
        /// <summary>
        /// 数据总记录
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 当前查询到数据集合
        /// </summary>
        public IEnumerable<T> rows { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageCount
        {
            get
            {
                if (pageSize <= 0) return 0;
                return total % pageSize == 0 ? total / pageSize : ((total / pageSize) + 1);
            }
        }
    }
}
