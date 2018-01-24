using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WangYc.Core.Infrastructure.Account;
using WangYc.Core.Infrastructure.Configuration;

namespace WangYc.Controllers.Controllers {
    public class BaseController : Controller {

        // GET: /Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);
              
            string loginpage = ApplicationSettingsFactory.GetApplicationSettings().LoginPage;
            string url = loginpage + "?ReturnUrl=" + Request.RawUrl;
             
            if (!AuthenticationFactory.Authentication().Verification) {
                filterContext.Result = Redirect(url);
            }
        }
    }
}