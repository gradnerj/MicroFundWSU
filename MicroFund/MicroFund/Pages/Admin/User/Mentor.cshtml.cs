using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Admin.User
{
    public class MentorModel : PageModel
    {
        private readonly IRepository _repository;
        private readonly ApplicationDbContext _context;
        public IList<ApplicationUser> ApplicationUsers { get; set; }
        public Dictionary<string, string> UserRoles { get; set; }

        public MentorModel(IRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            UserRoles = new Dictionary<string, string>();
            ApplicationUsers = await _repository.GetAllUsersAsync();
            IList<ApplicationUser> AllUsers;
            AllUsers = await _repository.GetAllUsersAsync();
            UserRoles = await _repository.GetUsersByRoleAsync("Mentor");

            foreach (var user in AllUsers)
            {
                if (!UserRoles.ContainsKey(user.Email))
                {
                    ApplicationUsers.Remove(user);
                }
            }
        }
        public async Task<IActionResult> OnPostLockUnlock(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user.LockoutEnd == null)
            {
                user.LockoutEnd = DateTime.Now.AddYears(100);
            }
            else if (user.LockoutEnd > DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now;
            }
            else
            {
                user.LockoutEnd = DateTime.Now.AddYears(100);
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
