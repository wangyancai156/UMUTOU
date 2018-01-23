using System.Web.Mvc;

namespace WangYc.MVC.Areas.BW {
    public class BWAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "BW";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                 "BW_default",
                 "BW/{controller}/{action}/{id}",
                 new { action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "WangYc.Controllers.Controllers.BW" }
            );
        }
    }
}
