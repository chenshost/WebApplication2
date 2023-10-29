using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebApplication2
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            settings.AutoRedirectMode = RedirectMode.Off;
            routes.EnableFriendlyUrls(settings);

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "Api_1",
                routeTemplate: "api/{controller}/{action}/{index}",
                defaults: new { action = "values", index = RouteParameter.Optional });

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "Api_2",
                routeTemplate: "api/{controller}/{action}/{not_used}",
                defaults: new { not_used = "-1" },
                constraints: new { action = "post_community" });
        }
    }
}
