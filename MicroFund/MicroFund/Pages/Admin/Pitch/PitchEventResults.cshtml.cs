using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace MicroFund.Pages.Admin.Pitch {
    public class PitchEventResultsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public PitchEventResultsModel(ApplicationDbContext context) {
            _context = context;
        }
        public PitchEvent PEvent { get; set; }
        public void OnGet(int eventid)
        {
            PEvent = _context.PitchEvents.FirstOrDefault(e => e.PitchId == eventid);
        }
    }
}
