using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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
        public IList<string> UserRoles { get; set; }
        [BindProperty]
        public List<string> AreChecked { get; set; }


        public async Task OnGetAsync(string id)
        {
            AppUser =  _repo.GetUserById(id);
            UserRoles = await _repo.GetUserRolesAsync(id);
            AreChecked = new List<string>();
        }

        public async Task<IActionResult> OnPostAsync() {

            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == AppUser.Id);
            if(user.Email != AppUser.Email)
            {
                user.Email = AppUser.Email;
                _context.ApplicationUsers.Update(user);
            }
            
            //remove all old roles
            var oldRoles = await _userManager.GetRolesAsync(AppUser);
            foreach(var role in oldRoles)
            {
                await _userManager.RemoveFromRoleAsync(AppUser, role);
            }
            await _context.SaveChangesAsync();

            //add checked roles
            foreach (var newRole in AreChecked.ToArray())
            {
                await _userManager.AddToRoleAsync(AppUser, newRole);
            }

            /*          
            if(oldRole.FirstOrDefault() != UserRoles) {
                await _userManager.RemoveFromRoleAsync(AppUser, oldRole.FirstOrDefault());
                await _userManager.AddToRoleAsync(AppUser, UserRole);
            }
            */

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
