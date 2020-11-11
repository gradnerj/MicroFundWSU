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
    public class DetailsModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public DetailsModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
