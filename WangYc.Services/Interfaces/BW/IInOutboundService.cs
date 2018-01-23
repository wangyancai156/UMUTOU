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
    public interface IInOutBoundService {


        #region 查找

        /// <summary>
        /// 获取出入库记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutBound> GetInOutBound(Query request);


        /// <summary>
        /// 获取出入库记录视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutBoundView> GetInOutBoundView(Query request);

        /// <summary>
        /// 获取所有库房列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutBoundView> GetInOutBoundView();

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<OutBound> GetOutBound(Query request);

        /// <summary>
        /// 获取出库记录视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<OutBoundView> GetOutBoundView(Query request);

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<InBound> GetInBound(Query request);

        /// <summary>
        /// 获取入库记录视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<InBoundView> GetInBoundView(Query request);
        
        /// <summary>
        /// 获取现货库存
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        IEnumerable<InBoundView> GetSpotInventory(int? productid);

        #endregion

        #region  添加
        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="request"></param>
        void AddInBound(AddInBoundRequest request);

        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="request"></param>
        void AddOutBound(int inboundId, int inboundShelfId, int qty, float price, string note, int createUserId);


        #endregion


    }
}
