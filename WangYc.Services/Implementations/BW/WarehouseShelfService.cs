using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Services.Implementations.BW {
    public class WarehouseShelfService : IWarehouseShelfService {

        private readonly IWarehouseShelfRepository _warehouseShelfRepository;
        private readonly IUnitOfWork _uow;

        public WarehouseShelfService(
            IWarehouseShelfRepository warehouseShelfRepository,
            IUnitOfWork uow
        ) {

            this._warehouseShelfRepository = warehouseShelfRepository;
            this._uow = uow;
        }

        #region 查找


        /// <summary>
        /// 获取货架
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WarehouseShelf> GetWarehouseShelf(Query request) {

            IEnumerable<WarehouseShelf> model = _warehouseShelfRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取货架视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WarehouseShelfView> GetWarehouseShelfView(Query request) {

            IEnumerable<WarehouseShelf> model = _warehouseShelfRepository.FindBy(request);
            return model.ConvertToWarehouseShelfView();
        }

        /// <summary>
        /// 根据库房编号获取货架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<WarehouseShelfView> GetWarehouseShelfViewByWarehoseId(int warehouseid) {

            Query query = new Query();
            query.Add(Criterion.Create<WarehouseShelf>(c => c.WarehouseId, warehouseid, CriteriaOperator.Equal));
            return GetWarehouseShelfView(query);
        }
  
        #endregion

        #region 添加

        /// <summary>
        ///添加库房
        /// </summary>
        /// <param name="request"></param>
        public void AddWarehouseShelf(AddWarehouseShelfRequest request) {

            WarehouseShelf model = new WarehouseShelf(request.Name, request.Capacity, request.Note, request.WarehouseId);
            this._warehouseShelfRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdateWarehouseShelf(AddWarehouseShelfRequest request) {

            WarehouseShelf model = this._warehouseShelfRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            model.Capacity = request.Capacity;
            model.Note = request.Note;
            model.WarehouseId = request.WarehouseId;
            this._warehouseShelfRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

    }
}
