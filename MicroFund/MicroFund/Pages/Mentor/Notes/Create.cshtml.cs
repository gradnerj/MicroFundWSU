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

        public async Task<IActionResult> OnGetAsync()
        {
            //get current user data
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //pass to form to provide UpdatedBy data
            CurrentUserId = claim.Value;

            //get all mentor assignments for the current logged in user/mentor
            var mentorAssignments = _repository.GetCurrentMentorAssignments(CurrentUserId);
            var iterations = await _repository.GetMentorAssignmentIterationPairsAsync(mentorAssignments);
            foreach( var assignment in mentorAssignments)
            {
                assignment.Application.DropDownName = assignment.Application.CompanyName + " - " + iterations[assignment.MentorAssignmentId];
            }


            //create dropdown
            ViewData["MentorAssignmentId"] = new SelectList(mentorAssignments, "MentorAssignmentId", "Application.DropDownName");

            //set datetime for default date on form
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

            //find and set mentor assignment to mentor note object
            MentorNote.MentorAssignment = _context.MentorAssignment.Where(x => x.MentorAssignmentId == MentorNote.MentorAssignmentId).FirstOrDefault();

            //get any files added to the form
            var files = HttpContext.Request.Form.Files;
            //if a file was uploaded
            if (files.Count != 0)
            {
                //get local path data
                string webRootPath = _hostingEnvironment.WebRootPath;
                //create unique file name
                string fileName = Guid.NewGuid().ToString() + "$&$%" + files[0].FileName;
                //combine with local path
                var uploads = Path.Combine(webRootPath, @"fileattachments\mentornotes");

                //save to server
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);

                }

                //update mentornote object
                MentorNote.MentorNoteFileAttachment = @"\fileattachments\mentornotes\" + fileName;
            }     

            //if mentor flagged application as approved for pitch event
            if (MentorNote.IsApproved)
            {
                //set date mentor flagged application ready for pitch event
                MentorNote.MentorAssignment.ApprovedToPitchDate = DateTime.Now;
                //get application in question
                MentorNote.MentorAssignment.Application = _repository.GetApplicationById(MentorNote.MentorAssignment.ApplicationId);
                //update application's status
                MentorNote.MentorAssignment.Application.ApplicationStatusId = _repository.GetStatusIdByName("Approved for Grant Review");
            }

            //add to table and save
            _context.MentorNote.Add(MentorNote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
