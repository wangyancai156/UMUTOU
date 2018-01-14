using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.Controllers.HR {
    public class RoleController : Controller {

        private readonly IRoleService _roleService;
        private readonly IRightsService _rightsService;
        public RoleController(IRoleService roleService,IRightsService rightsService) {

            this._roleService = roleService;
            this._rightsService = rightsService;
        }

        #region 角色管理
        
        public ActionResult Index() {

            return View();
        }

        public JsonResult GetRole() {

            IEnumerable<RoleView> model = this._roleService.GetRoleView();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddRole(string Organizationid, string Name, string Description, string rightsIds) {

            int organization = Convert.ToInt32(Organizationid);
            RoleView model = this._roleService.AddRole(organization, Name, Description, rightsIds);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveRole(int id) {
            try {
                this._roleService.DeleteRole(id);
                return Content("删除成功");
            }
            catch (Exception ex) {
                return Content("删除失败：" + ex.Message);
            }
        }

        public ActionResult UpdateRole(AddRoleRequest request) {
            try {

                this._roleService.UpdateRole(request);
                return Content("修改成功！");
            }
            catch (Exception ex) {
                return Content("修改失败：" + ex.Message);
            }
        }
        #endregion


        #region 权限功能
        public ActionResult AddRigths(string roleid) {

            int id = Convert.ToInt32(1002);
            RoleView model = this._roleService.GetRoleViewById(id);
            return View(model);
        }

        public JsonResult GetRigths(string roleid) {

            int id = Convert.ToInt32(roleid);
            RoleView model = this._roleService.GetRoleViewById(id);
            return Json(model.Rights, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRightsTreeView() {

            IEnumerable<DataTreeView> model = this._rightsService.GetRightsTreeView();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
