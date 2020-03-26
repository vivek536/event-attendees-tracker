using Event_Attendees_Tracker_CustomResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_DAL.Models;

namespace Event_Attendees_Tracker_DAL.DBQueries
{
    public interface IPastEvent
    {
        List<PastEventResponseModel> fetchPastEventAttendeesData(int userID);
        int getNumberOfStudentsRegistered(int eventID);
        int getNumberOfStudentsPresent(int eventID);
        List<EventDetails> getPastEventDetails(int userID);
    }
}
