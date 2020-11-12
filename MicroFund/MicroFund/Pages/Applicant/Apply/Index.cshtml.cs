using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Applicant.Apply
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            var applicant = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == "8a89b953-3a97-4a64-90f3-4e3061e08691");
    
        }
    }
}
