using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Attendees_Tracker_DAL.Tests.Models
{
   public class EventAttendees
    {
        public int ID { get; set; }

        public string QRString { get; set; }

        public bool isPresent { get; set; }

        public bool MailSent { get; set; }

        public RegisteredStudents RegisteredStudents { get; set; }

        //Event Details
        public EventDetails EventDetails { get; set; }
    }
}
