using System.Web.Mvc;

namespace WangYc.MVC.Areas.SD {
    public class SDAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "SD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
               "SD_default",
               "SD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WangYc.Controllers.Controllers.SD" }
            );
        }
    }
}
