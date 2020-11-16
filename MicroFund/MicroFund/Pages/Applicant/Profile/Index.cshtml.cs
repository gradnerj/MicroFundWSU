using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using EllipticCurve;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace MicroFund.Pages.Applicant.Profile
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;
       
        [BindProperty]
        public InputModel Input { get; set; }
        public ApplicationUser Applicant { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Demographics Demographics { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login");
            }
            else
            {
                if (User.IsInRole(StaticDetails.JudgeRole))
                {
                    return RedirectToPage("/Judge/Dashboard");
                }
                if (User.IsInRole(StaticDetails.MentorRole))
                {
                    return RedirectToPage("/Mentor/Dashboard");
                }
                else
                {
                    var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                    if(claim.Value == null)
                    {
                        return RedirectToPage("/Account/Login");
                    }

                    Applicant = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == claim.Value);
                    Address = await _context.Address.FirstOrDefaultAsync(d => d.ApplicantId == claim.Value);
                    
                    if(Address == null)
                    {
                        Input = new InputModel { FirstName = Applicant.FirstName, LastName = Applicant.LastName, Email = Applicant.Email };
                    }
                    else
                    {
                        ContactInfo = await _context.ContactInfo.FirstOrDefaultAsync(c => c.ApplicantId == claim.Value);
                        Demographics = await _context.Demographics.FirstOrDefaultAsync(d => d.ApplicationUserId == claim.Value);

                        Input = new InputModel { 
                            FirstName = Applicant.FirstName, 
                            LastName = Applicant.LastName,
                            Email = Applicant.Email,
                            ContactInfoDetail = ContactInfo.ContactInfoDetail,
                            Street = Address.Street,
                            City = Address.City,
                            State = Address.State,
                            Zip = Address.Zip,
                            Country = Address.Country,
                            Gender = Demographics.Gender,
                            RaceEthnicity = Demographics.RaceEthnicity,
                            DOB = Demographics.DOB,
                            Income = Demographics.Income,
                            HighestEduCompleted = Demographics.HighestEduCompleted,
                            ResidenceEnvironment = Demographics.ResidenceEnvironment,
                            CurrentStudent = Demographics.CurrentStudent,
                            VeteranStatus = Demographics.VeteranStatus,
                            WSUEntrepreneurshipMinor = Demographics.WSUEntrepreneurshipMinor,
                            WSUEmployee = Demographics.WSUEmployee,
                            WSUNumber = Demographics.WSUNumber
                        };
                    }

                    return Page();

                }
            }
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim.Value == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!ModelState.IsValid)
            {
                Applicant = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == claim.Value);
                Address = await _context.Address.FirstOrDefaultAsync(a => a.ApplicantId == claim.Value);
                ContactInfo = await _context.ContactInfo.FirstOrDefaultAsync(c => c.ApplicantId == claim.Value);
                Demographics = await _context.Demographics.FirstOrDefaultAsync(d => d.ApplicationUserId == claim.Value);

                return Page();
            }

            var applicant = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == claim.Value);
            var address = await _context.Address.FirstOrDefaultAsync(a => a.ApplicantId == claim.Value);
            var contactInfo = await _context.ContactInfo.FirstOrDefaultAsync(c => c.ApplicantId == claim.Value);
            var demographics = await _context.Demographics.FirstOrDefaultAsync(d => d.ApplicationUserId == claim.Value);

            if (address == null)
            {
                address = new Address();
            }
            if (contactInfo == null)
            {
                contactInfo = new ContactInfo();
            }
            if (demographics == null)
            {
                demographics = new Demographics();
            }

            applicant.FirstName = Input.FirstName;
            applicant.LastName = Input.LastName;
            applicant.Email = Input.Email;
            
            
            address.Street = Input.Street;
            address.City = Input.City;
            address.State = Input.State;
            address.Zip = Input.Zip;
            address.Country = Input.Country;
            address.UpdatedBy = claim.Value;
            address.UpdatedDate = DateTime.Now;

            contactInfo.ContactInfoDetail = Input.ContactInfoDetail;
            contactInfo.UpdatedBy = claim.Value;
            contactInfo.UpdatedDate = DateTime.Now;

            demographics.Gender = Input.Gender;
            demographics.RaceEthnicity = Input.RaceEthnicity;
            demographics.DOB = Input.DOB;
            demographics.Income = Input.Income;
            demographics.HighestEduCompleted = Input.HighestEduCompleted;
            demographics.ResidenceEnvironment = Input.ResidenceEnvironment;
            demographics.CurrentStudent = Input.CurrentStudent;
            demographics.VeteranStatus = Input.VeteranStatus;
            demographics.WSUEntrepreneurshipMinor = Input.WSUEntrepreneurshipMinor;
            demographics.WSUEmployee = Input.WSUEmployee;
            demographics.WSUNumber = Input.WSUNumber;
            demographics.UpdatedBy = claim.Value;
            demographics.UpdatedDate = DateTime.Now;


            if (demographics.ApplicationUserId != null)
            {
                _context.Address.Update(address);
                _context.ContactInfo.Update(contactInfo);
                _context.Demographics.Update(demographics);
            }
            else
            {
                address.ApplicantId = claim.Value;
                address.AddressType = await _context.AddressType.FirstOrDefaultAsync(a => a.AddressTypeDescription == "Residential");

                contactInfo.ApplicantId = claim.Value;
                contactInfo.ContactTypeId =  _context.ContactType.FirstOrDefault(t => t.ContactTypeDescription == "Cell").ContactTypeId;

                demographics.CreationDate = DateTime.Now;
                demographics.ApplicationUserId = claim.Value;

                _context.Address.Add(address);
                _context.ContactInfo.Add(contactInfo);
                _context.Demographics.Add(demographics);
            }

            _context.ApplicationUsers.Update(applicant);
            await _context.SaveChangesAsync();
            return RedirectToPage("./");
        }

        public class InputModel
        {
            [Required]
            [DisplayName("First Name")]
            public string FirstName { get; set; }
            [Required]
            [DisplayName("Last Name")]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [DisplayName("Cell Phone")]
            [Phone(ErrorMessage = "Please provide a valid phone number.")]
            public string ContactInfoDetail { get; set; }
            [Required]
            public string Street { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public string State { get; set; }
            [Required]
            [DisplayName("Zip Code")]
            public string Zip { get; set; }
            [Required]
            public string Country { get; set; }
            [Required]
            public string Gender { get; set; }
            [Required]
            [DisplayName("Race/Ethnicity")]
            public string RaceEthnicity { get; set; }
            [DisplayName("Date of Birth")]
            public DateTime DOB { get; set; }
            public float Income { get; set; }
            [Required]
            [DisplayName("Level of education completed")]
            public string HighestEduCompleted { get; set; }
            [Required]
            [DisplayName("Residence Environment")]
            public string ResidenceEnvironment { get; set; }
            public bool CurrentStudent { get; set; }
            public bool VeteranStatus { get; set; }
            public bool WSUEntrepreneurshipMinor { get; set; }
            public bool WSUEmployee { get; set; }
            [RegularExpression("^W{1}[0-9]{8}", ErrorMessage = "Please provide a valid W#, a W followed by 8 digits")]
            public string WSUNumber { get; set; }
        }
    }

}
