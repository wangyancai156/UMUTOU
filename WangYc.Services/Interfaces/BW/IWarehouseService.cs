using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Interfaces.BW {

    public interface IWarehouseService {

        #region 查找

        /// <summary>
        /// 获库房
        /// </summary>
        /// <returns></returns>
        IEnumerable<Warehouse> GetWarehouse(Query request);

        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<WarehouseView> GetWarehouseView(Query request);

        /// <summary>
        /// 获取所有库房视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<WarehouseView> GetWarehouseViewByAll();

        /// <summary>
        /// 通过ID获取库房视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WarehouseView GetWarehouseViewById(int id);

        #endregion

        #region 添加

        /// <summary>
        ///添加库房
        /// </summary>
        /// <param name="request"></param>
        void AddWarehouse(AddWarehouseRequest request);

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdateWarehouse(AddWarehouseRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房（只是作废）
        /// </summary>
        /// <param name="id"></param>
        void RemoveWarehouse(int id);
        
        #endregion

        #region  货架

        /// <summary>
        ///添加货架
        /// </summary>
        /// <param name="request"></param>
        void AddWarehouseShelf(AddWarehouseShelfRequest request);

        /// <summary>
        ///修改货架
        /// </summary>
        /// <param name="request"></param>
        void UpdateWarehouseShelf(AddWarehouseShelfRequest request);


        /// <summary>
        ///删除货架
        /// </summary>
        /// <param name="request"></param>
        void RemoveWarehouseShelf(int warehouseId, int id);

        #endregion

    }
}
