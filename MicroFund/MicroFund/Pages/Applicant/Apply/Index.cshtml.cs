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
            
            
            //var applicant = await _context.Applicant.FirstOrDefaultAsync(u => u.Id == "a26730a9-0400-4c5c-8c3a-ee63b4956f71");
            //DataAccessLayer.Models.Applicant app = (DataAccessLayer.Models.Applicant)applicant;
        }
    }
}
