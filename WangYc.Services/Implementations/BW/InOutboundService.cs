using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.BW;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.Repository.SD;
using WangYc.Models.SD;

namespace WangYc.Services.Implementations.BW {
    public class InOutBoundService : IInOutBoundService {

        private readonly IInOutBoundRepository _inOutBoundRepository;
        private readonly IOutBoundRepository _outBoundRepository;
        private readonly IInBoundRepository _inBoundRepository;
        private readonly IProductRepository  _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IWarehouseShelfRepository _warehouseShelfRepository;
        private readonly IUnitOfWork _uow;

        public InOutBoundService(
            IInOutBoundRepository inOutBoundRepository,
            IOutBoundRepository outBoundRepository,
            IInBoundRepository inBoundRepository,
            IProductRepository productRepository,
            IWarehouseRepository warehouseRepository,
            IWarehouseShelfRepository warehouseShelfRepository,
            IUnitOfWork uow
        ) {

            this._inOutBoundRepository = inOutBoundRepository;
            this._outBoundRepository = outBoundRepository;
            this._inBoundRepository = inBoundRepository;
            this._productRepository = productRepository;
            this._warehouseRepository = warehouseRepository;
            this._warehouseShelfRepository = warehouseShelfRepository;
            this._uow = uow;
        }

        #region 查找

        /// <summary>
        /// 获取出入库记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InOutBound> GetInOutBound(Query request) {

            IEnumerable<InOutBound> users = _inOutBoundRepository.FindBy(request);
            return users;
        }


        /// <summary>
        /// 获取出入库记录视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InOutBoundView> GetInOutBoundView(Query request) {

             GetInOutBound(request).ConvertToInOutBoundView();
             return null;
        }

        /// <summary>
        /// 获取所有库房列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InOutBoundView> GetInOutBoundView() {

            return  GetInOutBoundView(null);
        }

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OutBound> GetOutBound(Query query) {

            IEnumerable<OutBound> users = _outBoundRepository.FindBy(query);
            return users;
        }

        /// <summary>
        /// 获取出库记录视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OutBoundView> GetOutBoundView(Query query) {

            return GetOutBound(query).ConvertToOutBoundView();
        }

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InBound> GetInBound(Query query) {

            IEnumerable<InBound> users = _inBoundRepository.FindBy(query);
            return users;
        }

        /// <summary>
        /// 获取入库记录视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InBoundView> GetInBoundView(Query query) {

            return GetInBound(query).ConvertToInBoundView();
        }

        /// <summary>
        /// 获取现货库存
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public IEnumerable<InBoundView> GetSpotInventory(int? productid) {

            Query query = new Query();
            if (productid != null)
                query.Add(Criterion.Create<InBound>(p => p.Product.Id, productid, CriteriaOperator.Equal));
            query.Add(Criterion.Create<InBound>(p => p.CurrentQty, 0, CriteriaOperator.GreaterThanOrEqual));

            return GetInBound(query).ConvertToInBoundView();
        }

        #endregion

        #region  添加
        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="request"></param>
        public void AddInBound(AddInBoundRequest request) {

            Product product = this._productRepository.FindBy(request.ProductId);
            if (product == null) {
                throw new EntityIsInvalidException<string>(request.ProductId.ToString());
            }
            Warehouse warehouse = this._warehouseRepository.FindBy(request.WarehouseId);
            if (warehouse == null) {
                throw new EntityIsInvalidException<string>(request.WarehouseId.ToString());
            }
            WarehouseShelf warehouseShelf = this._warehouseShelfRepository.FindBy(request.WarehouseShelfId);
            if (warehouseShelf == null) {
                throw new EntityIsInvalidException<string>(request.WarehouseId.ToString());
            }


            InBound model = new InBound(product, warehouse, warehouseShelf, request.Qty, request.Price, request.Currency, request.Note, request.CreateUserId);
            this._inBoundRepository.Add(model);
            this._uow.Commit();
        }

        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="request"></param>
        public void AddOutBound(int inboundId, int inboundShelfId, int qty, float price, string note, int createUserId) {
 
            InBound inBound = this._inBoundRepository.FindBy(inboundId);

            inBound.AddOutBound(qty, price, note, createUserId, inboundShelfId);
            
            this._uow.Commit();
        }


        #endregion


    }
}
