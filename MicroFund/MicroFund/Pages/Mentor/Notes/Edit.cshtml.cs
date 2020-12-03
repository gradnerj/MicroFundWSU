using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MicroFund.Pages.Mentor.Notes
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;
        private readonly IRepository _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public string CurrentUserId { get; set; }
        [BindProperty]
        public MentorNote MentorNote { get; set; }
        public string FileName { get; set; }

        public EditModel(DataAccessLayer.Data.ApplicationDbContext context, IRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }



        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            var mentorAssignments = _repository.GetCurrentMentorAssignments(CurrentUserId);
            var companyNames = mentorAssignments.Select(x => x.Application.CompanyName).Distinct().ToList();
            ViewData["MentorAssignmentId"] = new SelectList(mentorAssignments, "MentorAssignmentId", "Application.CompanyName");

            MentorNote = _context.MentorNote.Where(x => x.MentorNoteId == id).Include(x => x.MentorAssignment).ThenInclude(x => x.Application).FirstOrDefault();

            //if there is a file attached to this note
            if (MentorNote.MentorNoteFileAttachment != null)
            {
                //get the actual file name (sans guid)
                string fullName = MentorNote.MentorNoteFileAttachment;
                string[] nameArray = fullName.Split("$&$%");
                FileName = nameArray[1];
            }

            if (MentorNote == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

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


                var originalFile = _context.MentorNote.Where(x => x.MentorNoteId == MentorNote.MentorNoteId).Select(x => x.MentorNoteFileAttachment).FirstOrDefault();
                
                var filePath = webRootPath + originalFile;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                

                //save to server
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);

                }

                //update mentornote object
                MentorNote.MentorNoteFileAttachment = @"\fileattachments\mentornotes\" + fileName;
            } else if(files.Count == 0)
            {
                var originalFile = _context.MentorNote.Where(x => x.MentorNoteId == MentorNote.MentorNoteId).Select(x => x.MentorNoteFileAttachment).FirstOrDefault();
                //update mentornote object
                MentorNote.MentorNoteFileAttachment = originalFile;
            }

            _context.Attach(MentorNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorNoteExists(MentorNote.MentorNoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MentorNoteExists(int id)
        {
            return _context.MentorNote.Any(e => e.MentorNoteId == id);
        }

      
    }
}
