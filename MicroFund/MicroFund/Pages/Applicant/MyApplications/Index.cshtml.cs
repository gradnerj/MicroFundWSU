using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models.ViewModels;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace MicroFund.Pages.Applicant.MyApplications
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;
        
        public ApplicantViewApplicationsVM ApplicantViewApplicationsVM { get; set; }

        public IndexModel(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login");
            }
            else
            {
                if(User.IsInRole(StaticDetails.JudgeRole)){
                    
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
                    
                    if(claim == null)
                    {
                        return RedirectToPage("/Account/Login");
                    }

                    ApplicantViewApplicationsVM = new ApplicantViewApplicationsVM
                    {
                        ApplicationUser = _repository.GetUserById(claim.Value),
                        Applications = await _repository.GetAllApplicationsByApplicationUserId(claim.Value)
                    };
                }
            
            }
            return Page();
        }
    }
}
