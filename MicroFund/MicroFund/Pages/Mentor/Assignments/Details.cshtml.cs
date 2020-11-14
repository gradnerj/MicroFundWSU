using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace MicroFund.Pages.Mentor.Assignments
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;
        private readonly IRepository _repository;
        public Application Application { get; set; }
        public MentorAssignment MentorAssignment { get; set; }
        public ApplicationUser Mentor { get; set; }
        public ApplicationUser Applicant { get; set; }
        public int Iteration { get; set; }
        public string UpdatedByName { get; set; }

        public DetailsModel(DataAccessLayer.Data.ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Application = new Application();
            Mentor = new ApplicationUser();

            Applicant = _repository.GetApplicantByApplicationId(id);
            Application = _repository.GetApplicationById(id);
            Mentor = _repository.GetMentorByApplicationId(id);
            Iteration = await _repository.GetIteration(Application.ApplicationId, Application.ApplicantId, Application.CompanyName);
            MentorAssignment = _repository.GetMentorAssignmentByApplicationId(id);
            if(MentorAssignment != null)
            {
                UpdatedByName = _repository.GetUserById(MentorAssignment.UpdatedBy).FullName;
            }

            return Page();
        }
    }
}
