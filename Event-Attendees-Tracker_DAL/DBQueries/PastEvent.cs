using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_DAL.Models;
using Event_Attendees_Tracker_CustomResponseModel;

namespace Event_Attendees_Tracker_DAL.DBQueries
{
   public class PastEvent:IPastEvent
    {
        static Event_Attendees_Tracker_DAL.Database_Context.EAT_DBContext _eatDBContext = Event_Attendees_Tracker_DAL.Instances.DBInstance.getDBInstance();
        static DateTime today = DateTime.Now;
        static TimeSpan time = today.TimeOfDay;
        /// <summary>
        /// Fetches Past Event Attendees Details
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public  List<PastEventResponseModel> fetchPastEventAttendeesData(int userID)
        {
            try
            {
                var fetchPastEventDetails = getPastEventDetails(userID);
                List<PastEventResponseModel> pastEventResponseList = new List<PastEventResponseModel>();

                foreach (var eventData in fetchPastEventDetails)
                {
                    PastEventResponseModel pastEventResponseModel = new PastEventResponseModel();
                    pastEventResponseModel.EventID = eventData.ID;
                    pastEventResponseModel.eventName = eventData.EventName;
                    pastEventResponseModel.numberOfStudentsRegistered = getNumberOfStudentsRegistered(eventData.ID);
                    pastEventResponseModel.numberOfStudentsPresent = getNumberOfStudentsPresent(eventData.ID);
                    pastEventResponseList.Add(pastEventResponseModel);
                }
                if (pastEventResponseList.Count == 0)
                {
                    return null;
                }

                return pastEventResponseList;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public  int getNumberOfStudentsRegistered(int eventID)
        {
            return _eatDBContext.EventAttendees.Where(eventAttendees => eventAttendees.EventDetails.ID == eventID).Count();

        }
        public  int getNumberOfStudentsPresent(int eventID)
        {
           return  _eatDBContext.EventAttendees.Where(eventAttendees => eventAttendees.EventDetails.ID == eventID && eventAttendees.isPresent == true).Count();
        }
        public virtual List<EventDetails> getPastEventDetails(int userID)
        {
            return _eatDBContext.EventDetails.Where(
                    events => events.CreatedBy == userID && (events.EventDate < today || (events.EventDate == today && events.EndTime <= time)))
                .OrderByDescending(events => events.EventDate).ToList();
        }


    }
}
