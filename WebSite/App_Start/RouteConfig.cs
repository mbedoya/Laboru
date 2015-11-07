using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Administration",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { controller = "AdminContent", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Security",
                url: "Security",
                defaults: new { controller = "Security", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "PlenumPage",
               url: "{*path}",
               defaults: new { controller = "Page", action = "Index" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}