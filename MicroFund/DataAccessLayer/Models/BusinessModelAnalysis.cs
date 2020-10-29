using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class BusinessModelAnalysis
    {
        [Key]
        [Display(Name = "Mentor")]
        public int MentorId { get; set; }

        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }

        public string MarketValidation { get; set; }

        public string ValueProp { get; set; }

        public string ValuePropValidation { get; set; }

        public string TargetCustomers { get; set; }

        public string Competition { get; set; }

        public string ToMarketStrategy { get; set; }

        public string FinancialProjections { get; set; }

        public string ManagementTeam { get; set; }

        public string CurrentStatus { get; set; }
    }
}
