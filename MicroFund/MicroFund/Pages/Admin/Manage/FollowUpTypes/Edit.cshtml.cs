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

namespace MicroFund.Pages.Admin.Manage.FollowUpTypes
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
        public FollowUpType FollowUpType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            if (id == null)
            {
                return NotFound();
            }

            FollowUpType = await _context.FollowUpType.FirstOrDefaultAsync(m => m.FollowUpTypeId == id);

            if (FollowUpType == null)
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

            _context.Attach(FollowUpType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowUpTypeExists(FollowUpType.FollowUpTypeId))
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

        private bool FollowUpTypeExists(int id)
        {
            return _context.FollowUpType.Any(e => e.FollowUpTypeId == id);
        }
    }
}
