using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_DAL.DBQueries;
using Event_Attendees_Tracker_DAL.Models;
using Newtonsoft.Json;

namespace Event_Attendees_Tracker_BAL.User_Actions
{
   public class FetchPastEvents
    {
        public static String fetchPastEventData(int userId)
        {
            var pastEventDetails = PastEvent.fetchPastEventData(userId);
            return JsonConvert.SerializeObject( pastEventDetails);


        }
    }
}
