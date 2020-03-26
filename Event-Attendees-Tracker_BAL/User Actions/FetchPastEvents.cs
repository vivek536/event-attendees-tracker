using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_DAL.DBQueries;
using Event_Attendees_Tracker_DAL.Models;

using Event_Attendees_Tracker_CustomResponseModel;
namespace Event_Attendees_Tracker_BAL.User_Actions
{
   public class FetchPastEvents:IFetchPastEvents
    {
        private readonly IPastEvent _pastEvent;
        public FetchPastEvents(IPastEvent pastEvent)
        {
            _pastEvent = pastEvent;
        }
        public  List<PastEventResponseModel> fetchPastEventAttendeesData(int userId)
        {
            try
            {
                var pastEventResponseDetails = _pastEvent.fetchPastEventAttendeesData(userId);
                if (pastEventResponseDetails == null)
                {
                    return null;
                }
                return pastEventResponseDetails;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
