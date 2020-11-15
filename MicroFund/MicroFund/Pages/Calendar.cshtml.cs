using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Repository;
using DataAccessLayer.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Utility;

namespace MicroFund.Pages {
    public class CalendarModel : PageModel
    {
        private readonly IRepository _repo;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CalendarModel(IRepository repo, ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _repo = repo;
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public IEnumerable<PitchEvent> Events { get; set; }

        public async Task OnGetAsync(string id)
        {
            var claimsPrincipal = User;
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            if (await _userManager.IsInRoleAsync(user, StaticDetails.AdminRole) || await _userManager.IsInRoleAsync(user, StaticDetails.JudgeRole)){
                Events = _context.PitchEvents.ToList().AsEnumerable();
            }
        }
    }
}
