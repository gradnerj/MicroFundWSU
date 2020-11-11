using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Repository;
using DataAccessLayer.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.Linq;
namespace MicroFund.Pages {
    public class CalendarModel : PageModel
    {
        private readonly IRepository _repo;
        private readonly ApplicationDbContext _context;

        public CalendarModel(IRepository repo, ApplicationDbContext context ) {
            _repo = repo;
            _context = context;
        }
        [BindProperty]
        public IEnumerable<PitchEvent> Events { get; set; }

        public void OnGet()
        {
            Events = _context.PitchEvents.ToList().AsEnumerable();
        }
    }
}
