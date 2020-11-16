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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) {
            _context = context;
        }
        public Application Application { get; set; }
        public IList<Response> Responses { get; set; }
        public void OnGet(int applicationid)
        {
            Application = _context.Application.FirstOrDefault(a => a.ApplicationId == applicationid);
            Responses = _context.Response.Where(r => r.ApplicationId == Application.ApplicationId)
                .Include(r => r.Question)
                .AsEnumerable()
                .ToList();
        }
    }
}
