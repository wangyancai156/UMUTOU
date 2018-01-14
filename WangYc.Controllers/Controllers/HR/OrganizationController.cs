using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using WangYc.Models.HR;
using System.Web.Mvc;

using WangYc.Services.Implementations.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels;

namespace WangYc.Controllers.Controllers.HR {

    public class OrganizationController : Controller {

        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService) {

            this._organizationService = organizationService;
        }

        public ActionResult Index() {

            return View();
        }
        /// <summary>获取组织树结构
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOrganizationTree() {

            IEnumerable<DataTreeView> organization = this._organizationService.GetOrganizationTreeView();
            return Json(organization, JsonRequestBehavior.AllowGet);

        }
        /// <summary>获取组织列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOrganization() {

            IEnumerable<OrganizationView> organization = this._organizationService.GetOrganization();
            return Json(organization, JsonRequestBehavior.AllowGet);

        }

        /// <summary>添加组织子节点
        /// </summary>
        /// <param name="id">组织名称</param>
        /// <param name="name">子节点名称</param>
        /// <param name="description">子节点说明</param>
        /// <returns></returns>
        public JsonResult AddOrganizationChild(int id, string name, string description) {

            OrganizationView organization = this._organizationService.AddOrganizationChild(id, name, description);
            return Json(organization, JsonRequestBehavior.AllowGet);
        }

        /// <summary>删除组织
        /// 删除组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteOrganization(int id) {

            this._organizationService.DeleteOrganization(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        /// <summary>修改组织
        /// 修改组织
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public JsonResult UpdateOrganization(int id, string name, string description) {

            OrganizationView organization = this._organizationService.UpdateOrganization(id, name, description);
            return Json(organization, JsonRequestBehavior.AllowGet);
        }

    }
}
