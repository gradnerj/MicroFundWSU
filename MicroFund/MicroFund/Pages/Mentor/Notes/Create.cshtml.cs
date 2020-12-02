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
using DataAccessLayer.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MicroFund.Pages.Mentor.Notes
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _context;
        private readonly IRepository _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public string CurrentUserId { get; set; }
        [BindProperty]
        public MentorNote MentorNote { get; set; }

        public CreateModel(IRepository repository, ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _repository = repository;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            var mentorAssignments = _repository.GetCurrentMentorAssignments(CurrentUserId);
            var companyNames = mentorAssignments.Select(x => x.Application.CompanyName).Distinct().ToList();
            ViewData["MentorAssignmentId"] = new SelectList(mentorAssignments, "MentorAssignmentId", "Application.CompanyName");

            MentorNote = new MentorNote()
            {
                MeetingDate = DateTime.Now
            };

            return Page();
        }        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            MentorNote.MentorAssignment = _context.MentorAssignment.Where(x => x.MentorAssignmentId == MentorNote.MentorAssignmentId).FirstOrDefault();

            string fileName = Guid.NewGuid().ToString() + "$" + files[0].FileName;
            var uploads = Path.Combine(webRootPath, @"fileattachments\mentornotes");
           // var extension = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
            {
                files[0].CopyTo(fileStream);

            }

            MentorNote.MentorNoteFileAttachment = @"\fileattachments\mentornotes\" + fileName;

            if (MentorNote.IsApproved)
            {
                MentorNote.MentorAssignment.ApprovedToPitchDate = DateTime.Now;
                MentorNote.MentorAssignment.Application = _repository.GetApplicationById(MentorNote.MentorAssignment.ApplicationId);
                MentorNote.MentorAssignment.Application.ApplicationStatusId = _repository.GetStatusIdByName("Approved for Grant Review");
            }
            _context.MentorNote.Add(MentorNote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
