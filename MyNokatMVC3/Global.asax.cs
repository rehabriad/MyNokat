using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyNokatMVC3
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "VoteToJoke", // Route name
            "User/VoteToJoke/{id}/{joke}/{voteType}", // URL with parameters
            new { controller = "User", action = "VoteToJoke", id = UrlParameter.Optional, joke = UrlParameter.Optional, voteType = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
            "PostJoke", // Route name
            "User/PostJoke/{id}/{joke}", // URL with parameters
            new { controller = "User", action = "PostJoke", id = UrlParameter.Optional, joke = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
            "User", // Route name
            "User/{id}", // URL with parameters
            new { controller = "User", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
 

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}