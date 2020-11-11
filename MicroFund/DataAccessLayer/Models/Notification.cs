using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models {
    public class Notification {
        [Key]
        public int NotificationID { get; set; }
        public string UserID { get; set; }
        public string NotificationMessage { get; set; }
    }
}
