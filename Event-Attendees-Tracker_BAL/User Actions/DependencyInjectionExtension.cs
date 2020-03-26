using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity.Mvc5;
using Unity;
using Event_Attendees_Tracker_DAL.DBQueries;
namespace Event_Attendees_Tracker_BAL.User_Actions
{
    public class DependencyInjectionExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPastEvent, PastEvent>();
        }
    }
}
