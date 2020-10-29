using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ApplicationScorecard
    {
        [Key]
        [Display(Name = "Application Details")]
        public int ApplicationDetailsId { get; set; }

        [ForeignKey("ApplicationDetailsId")]
        public ApplicationDetails ApplicationDetails { get; set; }

        public int MarketOpportunity { get; set; }

        public int Customers { get; set; }

        public int MarketingAndSales { get; set; }

        public int Competition { get; set; }

        public int Team { get; set; }

        public string Outcome { get; set; }

        public DateTime OutcomeDate { get; set; }

        [Display(Name = "Application User")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
