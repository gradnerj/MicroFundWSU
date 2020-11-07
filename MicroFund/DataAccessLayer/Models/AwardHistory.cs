using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class AwardHistory
    {
        public int AwardHistoryId { get; set; }

        [Required]
        [Display(Name = "Application")]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [Required]
        [Display(Name = "Expenditure")]
        public int ExpenditureId { get; set; }

        [Required]
        [ForeignKey("ExpenditureId")]
        public Expenditure Expenditure { get; set; }

        [Required]
        public DateTime AwardDate { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        [StringLength(64)]
        public string Agreement { get; set; }

        [Required]
        public int ReqNumber { get; set; }

        public DateTime MailedDate { get; set; }

        [StringLength(64)]
        public string Provider { get; set; }

        [StringLength(64)]
        public string AwardType { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
