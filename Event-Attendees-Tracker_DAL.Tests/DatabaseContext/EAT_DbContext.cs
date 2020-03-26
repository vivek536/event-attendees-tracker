using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event_Attendees_Tracker_DAL.Tests.Models;
namespace Event_Attendees_Tracker_DAL.Tests.DatabaseContext
{
    class EAT_DbContext:DbContext
    {
        public virtual DbSet<EventDetails> EventDetails { get; set; }
        public virtual DbSet<EventAttendees> EventAttendees { get; set; }
        public virtual DbSet<RegisteredStudents> RegisteredStudents { get; set; }
        public virtual DbSet<PointOfContact> PointOfContact { get; set; }
    }
}
