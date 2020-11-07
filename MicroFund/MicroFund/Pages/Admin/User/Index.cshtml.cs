using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MicroFund.Pages.Admin.User {
    public class IndexModel : PageModel {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IList<IdentityUser> ApplicationUsers { get; set; } 
        public Dictionary<string, string> UserRoles { get; set; }
        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            UserRoles = new Dictionary<string, string>();
            ApplicationUsers = await  _context.Users.ToListAsync();
            foreach(var appUser in ApplicationUsers) {
                var role = await _userManager.GetRolesAsync(appUser);
                UserRoles.Add(appUser.Email, role.FirstOrDefault());
            }
        }
    }
}
