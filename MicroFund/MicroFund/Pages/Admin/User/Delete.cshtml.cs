using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace MicroFund.Pages.Admin.User {
    public class DeleteModel : PageModel
    {
        private IRepository _repo;
        private ApplicationDbContext _context;
        public DeleteModel(IRepository repo, ApplicationDbContext context) {
            _repo = repo;
            _context = context;
        }
        [BindProperty]
        public ApplicationUser AppUser { get; set; }
        public void OnGet(string id)
        {
             AppUser = _repo.GetUserById(id);

        }

        public IActionResult OnPost() {
            var user = _context.ApplicationUsers.Where(u => u.Id == Request.Form["userId"].ToString()).FirstOrDefault();
            user.IsArchived = true;
            _context.ApplicationUsers.Update(user);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
