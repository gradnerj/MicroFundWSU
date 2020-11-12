﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public IndexModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MentorAssignment> MentorAssignment { get;set; }

        public async Task OnGetAsync()
        {
            MentorAssignment = await _context.MentorAssignment
                .Include(m => m.Application)
                .Include(m => m.Mentor).ToListAsync();
        }
    }
}
