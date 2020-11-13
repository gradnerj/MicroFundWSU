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
    public class IndexModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public IndexModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MentorNote> MentorNote { get;set; }

        public async Task OnGetAsync()
        {
            MentorNote = await _context.MentorNote
                .Include(m => m.MentorAssignment).ToListAsync();
        }
    }
}
