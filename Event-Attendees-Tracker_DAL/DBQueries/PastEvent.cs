using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_DAL.Models;

namespace Event_Attendees_Tracker_DAL.DBQueries
{
   public class PastEvent
    {
        static Event_Attendees_Tracker_DAL.Database_Context.EAT_DBContext _eatDBContext = Event_Attendees_Tracker_DAL.Instances.DBInstance.getDBInstance();

        public static List<EventDetails> fetchPastEventData(int userID)
        {
            DateTime today = DateTime.Now;
            Debug.Print(today.ToString("MM / dd / yyyy"));
            TimeSpan time = today.TimeOfDay;
            var fetchPastEventDetails = _eatDBContext.EventDetails.Where(
                events => events.CreatedBy == userID && events.EventDate <= today && events.EndTime<=time)
            .OrderByDescending(events => events.EventDate);
            //return fetchPastEventDetails.ToList();
            return fetchPastEventDetails.ToList();

            //&&
            // events.EventDate <= today



        }
    }
}
