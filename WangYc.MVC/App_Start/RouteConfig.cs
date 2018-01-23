using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WangYc.MVC {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HR123", // 路由名称，这个只要保证在路由集合中唯一即可
                url: "{controller}/{action}/{id}", //路由规则,匹配以Admin开头的url
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional } 
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            //);

            //  routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

        }
    }
}