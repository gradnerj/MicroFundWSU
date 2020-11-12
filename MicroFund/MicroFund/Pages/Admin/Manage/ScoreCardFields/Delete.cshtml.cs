using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace MicroFund.Pages.Admin.Manage.ScoreCardFields
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public DeleteModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScoreCardField ScoreCardField { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScoreCardField = await _context.ScoreCardField
                .Include(s => s.ScoringCategory).FirstOrDefaultAsync(m => m.ScoreCardFieldId == id);

            if (ScoreCardField == null)
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

            ScoreCardField = await _context.ScoreCardField.FindAsync(id);

            if (ScoreCardField != null)
            {
                ScoreCardField.IsArchived = true;
                _context.ScoreCardField.Update(ScoreCardField);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
