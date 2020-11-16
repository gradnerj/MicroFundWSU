using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Admin.Applications
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) {
            _context = context;
        }
        public IList<Application> Applications { get; set; }
        public IList<ApplicationUser> Users { get; set; }
        public void OnGet()
        {
            Applications = _context.Application
                .Include(a => a.ApplicationStatus)
                .AsEnumerable().ToList();
            Users = _context.ApplicationUsers.Where(u => Applications.Select(a => a.ApplicantId).AsEnumerable().ToList().Contains(u.Id)).AsEnumerable().ToList();
        }
    }
}
