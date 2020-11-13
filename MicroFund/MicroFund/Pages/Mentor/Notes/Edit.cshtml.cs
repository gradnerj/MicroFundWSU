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

namespace MicroFund.Pages.Mentor.Notes
{
    public class EditModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public EditModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MentorNote MentorNote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MentorNote = await _context.MentorNote
                .Include(m => m.MentorAssignment).FirstOrDefaultAsync(m => m.MentorNoteId == id);

            if (MentorNote == null)
            {
                return NotFound();
            }
           ViewData["MentorAssignmentId"] = new SelectList(_context.MentorAssignment, "MentorAssignmentId", "MentorId");
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
