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

namespace MicroFund.Pages.Mentor.Assignments
{
    public class EditModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public EditModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MentorAssignment MentorAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MentorAssignment = await _context.MentorAssignment
                .Include(m => m.Application)
                .Include(m => m.Mentor).FirstOrDefaultAsync(m => m.MentorAssignmentId == id);

            if (MentorAssignment == null)
            {
                return NotFound();
            }
           ViewData["ApplicationId"] = new SelectList(_context.Application, "ApplicationId", "ApplicantId");
           ViewData["MentorId"] = new SelectList(_context.Users, "Id", "Id");
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

            _context.Attach(MentorAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorAssignmentExists(MentorAssignment.MentorAssignmentId))
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

        private bool MentorAssignmentExists(int id)
        {
            return _context.MentorAssignment.Any(e => e.MentorAssignmentId == id);
        }
    }
}
