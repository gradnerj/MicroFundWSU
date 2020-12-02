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
using Microsoft.AspNetCore.Identity;

namespace MicroFund.Pages.Mentor.Notes
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _context;
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        public IList<Application> MentorApplications { get; set; }
        public string CurrentUserId { get; set; }
        public Dictionary<int, string> ApplicationApplicantPairs { get; set; }

        public CreateModel(IRepository repository, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            var mentorAssignments = _repository.GetCurrentMentorAssignments(CurrentUserId);
            var companyNames = mentorAssignments.Select(x => x.Application.CompanyName).Distinct().ToList();
            ViewData["MentorAssignmentId"] = new SelectList(mentorAssignments, "MentorAssignmentId", "Application.CompanyName");

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

            MentorNote.MentorAssignment = _context.MentorAssignment.Where(x => x.MentorAssignmentId == MentorNote.MentorAssignmentId).FirstOrDefault();
            if(MentorNote.IsApproved)
            {
                MentorNote.MentorAssignment.ApprovedToPitchDate = DateTime.Now;
                MentorNote.MentorAssignment.Application = _repository.GetApplicationById(MentorNote.MentorAssignment.ApplicationId);
                MentorNote.MentorAssignment.Application.ApplicationStatusId = _repository.GetStatusIdByName("Approved for Grant Review");

                var admins = await _userManager.GetUsersInRoleAsync("Admin");
                foreach (var a in admins)
                {
                    var notification = new Notification
                    {
                        UserID = a.Id,
                        NotificationMessage = "New Request for Pitch"
                    };
                    _context.Notifications.Add(notification);
                    _context.SaveChanges();
                }
            }
            _context.MentorNote.Add(MentorNote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
