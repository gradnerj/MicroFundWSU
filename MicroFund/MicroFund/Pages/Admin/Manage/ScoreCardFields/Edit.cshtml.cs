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
using System.Security.Claims;

namespace MicroFund.Pages.Admin.Manage.ScoreCardFields
{
    public class EditModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;
        public string CurrentUserId;

        public EditModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScoreCardField ScoreCardField { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;


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
           ViewData["ScoringCategoryId"] = new SelectList(_context.ScoringCategory, "ScoringCategoryId", "ScoringCategoryDescription");
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

            _context.Attach(ScoreCardField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreCardFieldExists(ScoreCardField.ScoreCardFieldId))
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

        private bool ScoreCardFieldExists(int id)
        {
            return _context.ScoreCardField.Any(e => e.ScoreCardFieldId == id);
        }
    }
}
