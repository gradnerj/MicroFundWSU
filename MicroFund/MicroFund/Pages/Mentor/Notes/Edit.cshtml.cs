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

namespace MicroFund.Pages.Mentor.Notes
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;
        private readonly IRepository _repository;
        public string CurrentUserId { get; set; }
        [BindProperty]
        public MentorNote MentorNote { get; set; }

        public EditModel(DataAccessLayer.Data.ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        

        public async Task<IActionResult> OnGetAsync(int? id)
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
