using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_CustomResponseModel;

namespace Event_Attendees_Tracker_BAL.User_Actions
{
   public interface IFetchPastEvents
    {
      List<PastEventResponseModel> fetchPastEventAttendeesData(int userId);
    }
}
