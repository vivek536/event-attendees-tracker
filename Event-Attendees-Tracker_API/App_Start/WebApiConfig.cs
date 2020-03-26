using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Event_Attendees_Tracker_BAL.User_Actions;
using Event_Attendees_Tracker_API.Models;
using Unity.Lifetime;

namespace Event_Attendees_Tracker_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var container = new UnityContainer();
            //container.RegisterType<IFetchPastEvents, FetchPastEvents>(new HierarchicalLifetimeManager());
            //config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "UserApi",
               routeTemplate: "api/{controller}/{action}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
