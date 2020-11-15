using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Security.Claims;

namespace MicroFund.Pages.Mentor.Notes
{
    public class CreateModel : PageModel
    {
        private readonly IRepository _repository;
        public IList<Application> MentorApplications { get; set; }
        public string CurrentUserId { get; set; }
        public Dictionary<int, string> ApplicationApplicantPairs { get; set; }
        public bool IsApproved { get; set; }

        public CreateModel(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            var mentorAssignments = _repository.GetCurrentMentorAssignments(CurrentUserId);
            var companyNames = mentorAssignments.Select(x => x.Application.CompanyName).Distinct().ToList();
            ViewData["MentorAssignmentId"] = new SelectList(mentorAssignments, "MentorAssignmentId", "Application.CompanyName");

            //MentorApplications = await _repository.GetMentorApplicationsAsync(CurrentUserId);
            //ApplicationApplicantPairs = await _repository.GetApplicationIdApplicantNamePairs(MentorApplications);
            //MentorNote = await _repository.GetMentorNotes(CurrentUserId);

            return Page();
        }

        [BindProperty]
        public MentorNote MentorNote { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.MentorNote.Add(MentorNote);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
