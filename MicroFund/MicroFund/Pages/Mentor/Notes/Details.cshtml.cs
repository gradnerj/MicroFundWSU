using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace MicroFund.Pages.Mentor.Notes
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public DetailsModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
