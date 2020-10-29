using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Applicant
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public DateTime Date { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string CellPhone { get; set; }
    }
}
