using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eStanar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EditPoll",
                url: "Poll/{action}/{idPoll}",
                defaults: new { controller = "Poll", action = "EditPoll", idPoll = 1 }
            );

            routes.MapRoute(
                name: "Notices",
                url: "Notice/{action}/{id}",
                defaults: new { controller = "Notice", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
