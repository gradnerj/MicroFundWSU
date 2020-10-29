using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Address
    {
        [Key]
        [Display(Name = "Applicant")]
        public int ApplicantId { get; set; }

        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int Zip { get; set; }

        public string Country { get; set; }
    }
}
