using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Interfaces.BW {
    public interface IWarehouseShelfService {

        /// <summary>
        /// 根据库房编号获取货架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<WarehouseShelfView> GetWarehouseShelfViewByWarehoseId(int warehouseid);

    }
}
