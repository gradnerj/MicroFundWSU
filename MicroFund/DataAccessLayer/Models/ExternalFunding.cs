using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ExternalFunding
    {
        [Key]
        [Display(Name = "Application Details")]
        public int ApplicationDetailsId { get; set; }

        [ForeignKey("ApplicationDetailsId")]
        public ApplicationDetails ApplicationDetails { get; set; }

        public float Amount { get; set; }

        public string Source { get; set; }

        public DateTime Date { get; set; }
    }
}
