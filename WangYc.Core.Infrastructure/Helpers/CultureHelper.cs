using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WangYc.Core.Infrastructure.Helpers {
    public class CultureHelper {

        public static void SetUserCulture() {
            string cultureName = "zh-CN";

            HttpCookie cultureCookie = HttpContext.Current.Request.Cookies["Region"];
            if (cultureCookie != null) {
                string region = cultureCookie.Values["Name"];
                switch (region) {
                    case "CN":
                        cultureName = "zh-CN";
                        break;
                    default:
                        cultureName = "en-US";
                        break;
                }
            }

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }
    }
}
