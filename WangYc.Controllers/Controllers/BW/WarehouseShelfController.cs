using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Controllers.Controllers.BW {
    public class WarehouseShelfController : Controller {

        private readonly IWarehouseService _warehouseService;
        private readonly IWarehouseShelfService _warehouseShelfService;
        public WarehouseShelfController(IWarehouseService warehouseService, IWarehouseShelfService warehouseShelfService) {

            this._warehouseService = warehouseService;
            this._warehouseShelfService = warehouseShelfService;
        }

        public ActionResult Index(int warehouseId) {

            WarehouseView model = this._warehouseService.GetWarehouseViewById(warehouseId);
            return View(model);
        }


        #region 货架号

        public JsonResult GetWarehouseShelf(int warehouseId) {

            IEnumerable<WarehouseShelfView> model = this._warehouseShelfService.GetWarehouseShelfViewByWarehoseId(warehouseId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

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
