using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Demographic
    {
        [Key]
        [Display(Name = "Applicant")]
        public int ApplicantId { get; set; }

        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }

        public string HighestLevelEducationCompleted { get; set; }

        public string WNumber { get; set; }

        public string Gender { get; set; }

        public string RaceOrEthnicity { get; set; }

        public string AgeRange { get; set; }

        public string IncomeRange { get; set; }

        public string ResidenceEnvironment { get; set; }

        public string MilitaryStatus { get; set; }
    }
}
