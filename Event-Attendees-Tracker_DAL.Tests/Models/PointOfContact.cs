using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Attendees_Tracker_DAL.Tests.Models
{
    public class PointOfContact
    {
        #region Properties        

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        #endregion
    }
}
