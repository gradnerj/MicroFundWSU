using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MicroFund.Pages.Admin.User {
    public class UpdateModel : PageModel
    {
        private ApplicationDbContext _context;
        private IRepository _repo;
        public UpdateModel(ApplicationDbContext context, IRepository repo) {
            _context = context;
            _repo = repo;
        }
        [BindProperty]
        public ApplicationUser AppUser { get; set; }
        public string UserRole { get; set; }
        public async Task OnGetAsync(string id)
        {
            AppUser =  _repo.GetUserById(id);
            UserRole = await _repo.GetUserRoleAsync(id);
        }

        public async Task<IActionResult> OnPostAsync() {
            _context.ApplicationUsers.Update(AppUser);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
