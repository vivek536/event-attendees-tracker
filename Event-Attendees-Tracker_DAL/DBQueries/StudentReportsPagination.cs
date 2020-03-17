using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_CustomResponseModel;
namespace Event_Attendees_Tracker_DAL.DBQueries
{
    public class StudentReportsPagination
    {
        static Event_Attendees_Tracker_DAL.Database_Context.EAT_DBContext _eatDBContext = Event_Attendees_Tracker_DAL.Instances.DBInstance.getDBInstance();
        public static IQueryable EventAttendeesList(int EventID)
        {      
            var query = from EventAttendees in _eatDBContext.EventAttendees
                        join RegS in _eatDBContext.RegisteredStudents on EventAttendees.RegisteredStudents.ID equals RegS.ID
                        where EventAttendees.EventDetails.ID == EventID
                        select new { EventAttendees.ID, RegS.FirstName, RegS.LastName, RegS.EmailID };
            return query;
        }

    }
}
