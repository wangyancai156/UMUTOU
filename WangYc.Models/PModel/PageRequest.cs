using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Models.PModel
{
    /// <summary>
    /// 查询基类
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// 
        /// </summary>
        private int _page = 1;
        /// <summary>
        /// 页数
        /// </summary>
        public int page
        {
            get { return _page; }
            set { _page = value; }
        }
        private int _rows = 20;
        /// <summary>
        /// 显示条数
        /// </summary>
        public int rows
        {
            get { return _rows; }
            set { _rows = value; }
        }
        public int betweenStart { get { return ((page - 1) * rows) + 1; } }
        public int betweenEnd { get { return page * rows; } }
    }
}
