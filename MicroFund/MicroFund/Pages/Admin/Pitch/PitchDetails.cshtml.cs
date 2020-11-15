using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MicroFund.Pages.Admin.Pitch {
    public class PitchDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public PitchDetailsModel(ApplicationDbContext context) {
            _context = context;
        }

        public DataAccessLayer.Models.Pitch Pitch { get; set; }

        public void OnGet(int pitchid)
        {
            Pitch = _context.Pitch.Where(p => p.PitchId == pitchid)
                .Include(p => p.Application)
                .FirstOrDefault();
        }
    }
}
