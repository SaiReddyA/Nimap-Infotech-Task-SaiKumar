using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //"Search", "Search/{query}/{startIndex}", new
            //{
            //    controller = "Home",
            //    action = "Search",
            //    startIndex = 0,
            //    pageSize = 2
            //});
            routes.MapRoute(
            name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Catagory", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
