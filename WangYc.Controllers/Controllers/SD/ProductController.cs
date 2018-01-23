using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WangYc.Services.Interfaces.SD;
using WangYc.Services.Messaging;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Controllers.Controllers.SD {
    public class ProductController : Controller {

        private readonly IProductService _productService;

        public ProductController(IProductService productService) {

            this._productService = productService;
        }

        public ActionResult Index() {

            return View();
        }

        public JsonResult GetProduct() {

           IEnumerable<ProductView> model = this._productService.GetProductViewByAll();
           return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult AddProduct(AddProductRequest request) {

            this._productService.AddProduct(request);
            return Json("添加成功！", JsonRequestBehavior.AllowGet);
        }
       /// <summary>
       /// 修改产品
       /// </summary>
       /// <param name="request"></param>
       /// <returns></returns>
        public JsonResult UpdateProduct(AddProductRequest request) {

            this._productService.UpdateProduct(request);
            return Json("添加成功！", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult RemoveProduct(int id) {

            this._productService.RemoveProduct(id);
            return Json("删除成功！", JsonRequestBehavior.AllowGet);
        }

    }
}
