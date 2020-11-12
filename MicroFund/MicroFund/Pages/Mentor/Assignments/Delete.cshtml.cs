using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace MicroFund.Pages.Mentor.Assignments
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public DeleteModel(DataAccessLayer.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MentorAssignment = await _context.MentorAssignment.FindAsync(id);

            if (MentorAssignment != null)
            {
                _context.MentorAssignment.Remove(MentorAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
