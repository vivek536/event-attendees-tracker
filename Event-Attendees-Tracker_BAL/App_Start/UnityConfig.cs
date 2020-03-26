using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Event_Attendees_Tracker_DAL.DBQueries;

namespace Event_Attendees_Tracker_BAL
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<IPastEvent, PastEvent>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}