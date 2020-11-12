using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace MicroFund.Pages.Admin.Manage.AddressTypes
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public DeleteModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddressType AddressType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressType = await _context.AddressType.FirstOrDefaultAsync(m => m.AddressTypeId == id);

            if (AddressType == null)
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

            AddressType = await _context.AddressType.FindAsync(id);

            if (AddressType != null)
            {
                AddressType.IsArchived = true;
                _context.AddressType.Update(AddressType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
