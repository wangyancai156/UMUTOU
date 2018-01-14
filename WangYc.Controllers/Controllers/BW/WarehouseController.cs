using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using WangYc.Models.HR;
using System.Web.Mvc;

using WangYc.Services.Implementations.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels;
using WangYc.Models.BW;

namespace WangYc.Controllers.Controllers.BW {
    public class WarehouseController : Controller {

        private readonly IWarehouseService _warehouseService;
        private readonly IWarehouseShelfService _warehouseShelfService;
        public WarehouseController(IWarehouseService warehouseService, IWarehouseShelfService warehouseShelfService) {

            this._warehouseService = warehouseService;
            this._warehouseShelfService = warehouseShelfService;
        }
 
        public ActionResult Index() {

            return View();
        }

        #region 库房
        /// <summary>
        /// 获取库房列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetWarehouse() {

            IEnumerable<WarehouseView> model = this._warehouseService.GetWarehouseViewByAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加库房
        /// </summary>
        /// <returns></returns>
        public JsonResult AddWarehouse(AddWarehouseRequest request) {

            this._warehouseService.AddWarehouse(request);
            return Json("添加成功", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateWarehouse(AddWarehouseRequest request) {
 
            this._warehouseService.UpdateWarehouse(request);
            return Json("修改成功", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <returns></returns>
        public JsonResult RemoveWarehouse(int id ) {

            this._warehouseService.RemoveWarehouse(id);
            return Json("修改成功", JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 货架号

        /// <summary>
        /// 添加货架号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult AddWarehouseShelf(AddWarehouseShelfRequest request) {

            this._warehouseService.AddWarehouseShelf(request);
            return Json("添加成功", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改货架号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult UpdateWarehouseShelf(AddWarehouseShelfRequest request) {

            this._warehouseService.UpdateWarehouseShelf(request);
            return Json("修改成功", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除货架号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult RemoveWarehouseShelf(int warehouseId, int id) {

            this._warehouseService.RemoveWarehouseShelf(warehouseId, id);
            return Json("删除成功", JsonRequestBehavior.AllowGet);
        }

            
        #endregion
    }
}
