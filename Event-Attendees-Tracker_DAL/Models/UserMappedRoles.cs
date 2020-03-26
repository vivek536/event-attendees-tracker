﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Attendees_Tracker_DAL.Models
{
    [Table("UserMappedRoles")]
    public class UserMappedRoles
    {
        #region Properties
        public int ID { get; set; }
        public UserDetails UserDetails { get; set; }
        public Master_DBRoles Master_DBRoles { get; set; }
        #endregion
    }
}

