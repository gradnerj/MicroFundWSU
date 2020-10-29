using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class GrantPhase
    {
        public int Id { get; set; }

        [Display(Name = "Pitch")]
        public int PitchId { get; set; }

        [ForeignKey("PitchId")]
        public Pitch Pitch { get; set; }

        public DateTime AwardDate { get; set; }

        public float Amount { get; set; }

        public float Requested { get; set; }

        public string Agreement { get; set; }

        public int ReqNumber { get; set; }

        public DateTime MailedDate { get; set; }

        public string Provider { get; set; }

        public DateTime DateInKindUsed { get; set; }

        public DateTime DateInKindCompleted { get; set; }
    }
}
