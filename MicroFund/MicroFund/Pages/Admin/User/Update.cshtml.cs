using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace MicroFund.Pages.Admin.User {
    public class UpdateModel : PageModel
    {
        private ApplicationDbContext _context;
        private IRepository _repo;
        private UserManager<IdentityUser> _userManager;
        public UpdateModel(ApplicationDbContext context, IRepository repo, UserManager<IdentityUser> userManager) {
            _context = context;
            _repo = repo;
            _userManager = userManager;
        }
        [BindProperty]
        public ApplicationUser AppUser { get; set; }
        [BindProperty]
        public string UserRole { get; set; }


        public async Task OnGetAsync(string id)
        {
            AppUser =  _repo.GetUserById(id);
            UserRole = await _repo.GetUserRoleAsync(id);
        }

        public async Task<IActionResult> OnPostAsync() {
            _context.ApplicationUsers.Update(AppUser);
            
            var oldRole = await _userManager.GetRolesAsync(AppUser);
            if(oldRole.FirstOrDefault() != UserRole) {
                await _userManager.RemoveFromRoleAsync(AppUser, oldRole.FirstOrDefault());
                await _userManager.AddToRoleAsync(AppUser, UserRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
