﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Expenditure
    {
        public int ExpenditureId { get; set; }

        [Required]
        [Display(Name = "AwardHistory")]
        public int AwardHistoryId { get; set; }

        [Required]
        [ForeignKey("AwardHistoryId")]
        public AwardHistory AwardHistory { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
