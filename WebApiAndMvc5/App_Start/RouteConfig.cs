using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApiAndMvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = false;

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Empty",
                url: "",
                defaults: new { controller = "MVCTEST", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MVCTEST", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
