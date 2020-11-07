using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Repository;

namespace MicroFund.Pages.Admin.User {
    public class IndexModel : PageModel {
        private readonly IRepository _repository;
        public IList<IdentityUser> ApplicationUsers { get; set; } 
        public Dictionary<string, string> UserRoles { get; set; }
        public IndexModel(IRepository repository) {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            UserRoles = new Dictionary<string, string>();
            ApplicationUsers = await _repository.GetAllUsersAsync();
            UserRoles = await _repository.GetAllUserRolesAsync();
        }
    }
}
