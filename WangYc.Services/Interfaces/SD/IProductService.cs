using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.SD;
using WangYc.Services.Messaging;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.Interfaces.SD {
    public interface IProductService {


        #region 查找

        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProduct(Query request);

        /// <summary>
        /// 获取产品视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductView> GetProductView(Query request);
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductView> GetProductViewByAll();
        /// <summary>
        /// 根据名称获取产品
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<ProductView> GetProductViewByName(string name);
        #endregion

        #region 添加
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="request"></param>
        void AddProduct(AddProductRequest request);

        #endregion

        #region 修改
        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="request"></param>
        void UpdateProduct(AddProductRequest request);
        #endregion

        #region 删除
        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="request"></param>
        void  RemoveProduct(int id);
        #endregion

    }
}
