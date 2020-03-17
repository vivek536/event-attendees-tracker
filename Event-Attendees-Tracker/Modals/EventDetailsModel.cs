using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Attendees_Tracker.Modals
{
    
    public class EventDetailsModel
    {
       
        public int ID { get; set; }
        
        public string EventName { get; set; }
        
        public string Description { get; set; }
      
        public string Venue { get; set; }
        
        public TimeSpan StartTime { get; set; }

        
        public TimeSpan EndTime { get; set; }

       
        public DateTime? EventDate { get; set; }
   
        public string PosterImage { get; set; }
        
        public bool isActive { get; set; }

        
        public DateTime CreatedAt { get; set; }

        //TODO:
        //Change to UserDetails
       
        public int? CreatedBy { get; set; }

        
        public DateTime? UpdatedAt { get; set; }
        
        //TODO:
        //Change to UserDetails
        public int? UpdatedBy { get; set; }
        
        public bool CanRegister { get; set; }
    }
}