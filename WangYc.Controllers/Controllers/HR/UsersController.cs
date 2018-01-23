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
    public class UsersController : Controller {

        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService) {
            this._usersService = usersService;
        }

        public ActionResult Index() {

            return View();
        }

     
        public ActionResult Bootstrap() {
            return View();
        }
 
        public JsonResult GetUsers() {
 
            IEnumerable<UsersView> usersView = _usersService.GetUsersView();

            return Json(usersView, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddUsers(AddUsersRequest request) {
            try {
                _usersService.InsertUsers(request);
                return Content("添加成功！");
            }
            catch (Exception ex) {
                throw ex;
            }

        }
        public ActionResult RemoveUsers(string userid) {
            try {
                _usersService.DeleteUsers(userid);
                return Content("删除成功");
            }
            catch (Exception ex) {
                return Content("删除失败：" + ex.Message);
            }
        }


        public ActionResult UpdateUsers(AddUsersRequest request) {
            try {

                _usersService.UpdateUsers(request);
                return Content("修改成功！");
            }
            catch (Exception ex) {
                return Content("修改失败：" + ex.Message);
            }
        }
    }
}