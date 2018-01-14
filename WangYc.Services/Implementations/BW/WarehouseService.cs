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
    public class WarehouseService : IWarehouseService {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _uow;

        public WarehouseService(
            IWarehouseRepository warehouseRepository,
            IUnitOfWork uow
        ) {

            this._warehouseRepository = warehouseRepository;
            this._uow = uow;
        }
        #region 库房

        #region 查找

        /// <summary>
        /// 获库房
        /// </summary>
        /// <returns></returns>
        public Warehouse GetWarehouse(int id) {

            return this._warehouseRepository.FindBy(id);
        }

        /// <summary>
        /// 获库房列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Warehouse> GetWarehouse(Query request) {

            IEnumerable<Warehouse> model = _warehouseRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WarehouseView> GetWarehouseView(Query request) {

            IEnumerable<Warehouse> model = this._warehouseRepository.FindBy(request);
            return model.ConvertToWarehouseView();
        }

        /// <summary>
        /// 获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WarehouseView> GetWarehouseViewByAll() {

            return this._warehouseRepository.FindAll().ConvertToWarehouseView();
        }

        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public WarehouseView GetWarehouseViewById(int id) {

            return GetWarehouse(id).ConvertToWarehouseView();
        }


        #endregion

        #region 添加

        /// <summary>
        ///添加库房
        /// </summary>
        /// <param name="request"></param>
        public void AddWarehouse(AddWarehouseRequest request) {

            Warehouse model = new Warehouse(request.Name, request.Note, request.WarehouseTypeId);
            this._warehouseRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdateWarehouse(AddWarehouseRequest request) {

            Warehouse model = this._warehouseRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            model.Name = request.Name;
            model.Note = request.Note;
            model.WarehouseTypeId = request.WarehouseTypeId;
            this._warehouseRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemoveWarehouse(int id) {

            Warehouse model = this._warehouseRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.State = false;
            this._warehouseRepository.Save(model);
            this._uow.Commit();
        }
        #endregion

        #endregion

        #region  货架

        /// <summary>
        ///添加货架
        /// </summary>
        /// <param name="request"></param>
        public void AddWarehouseShelf(AddWarehouseShelfRequest request) {

            Warehouse model = this._warehouseRepository.FindBy(request.WarehouseId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.WarehouseId.ToString());
            }
            model.AddWarehouseShelf(request.Name, request.Capacity, request.Note);
            this._warehouseRepository.Add(model);
            this._uow.Commit();
        }

        /// <summary>
        ///修改货架
        /// </summary>
        /// <param name="request"></param>
        public void UpdateWarehouseShelf(AddWarehouseShelfRequest request) {

            Warehouse model = this._warehouseRepository.FindBy(request.WarehouseId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.WarehouseId.ToString());
            }
            model.UpdateWarehouseShelf(request.Id, request.Name, request.Capacity, request.Note);
            this._warehouseRepository.Save(model);
            this._uow.Commit();
        }


        /// <summary>
        ///删除货架
        /// </summary>
        /// <param name="request"></param>
        public void RemoveWarehouseShelf(int warehouseId, int  id) {

            Warehouse model = this._warehouseRepository.FindBy(warehouseId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(warehouseId.ToString());
            }
            model.RemoveWarehouseShelf(id);
            this._warehouseRepository.Save(model);
            this._uow.Commit();
        }

        #endregion
    }
}
