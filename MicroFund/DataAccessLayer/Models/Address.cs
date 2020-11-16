using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required]
        [Display(Name = "Applicant")]
        public string ApplicantId { get; set; }


        [Display(Name = "AddressType")]
        public int AddressTypeId { get; set; }

        [Required]
        [ForeignKey("AddressTypeId")]
        public AddressType AddressType { get; set; }

        [Required]
        [StringLength(64)]
        [DisplayName("Street Address")]
        public string Street { get; set; }

        [Required]
        [StringLength(64)]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [DisplayName("Zip Code")]
        public string Zip { get; set; }

        [Required]
        [StringLength(64)]
        public string Country { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
