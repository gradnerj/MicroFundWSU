using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository {
    public class Repository : IRepository {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public Repository(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        #region CREATE Methods
        #endregion

        #region RETRIEVE Methods
        public async Task<Dictionary<string, string>> GetAllUserRolesAsync() {
            var rolesDict = new Dictionary<string, string>();
            var users = await GetAllUsersAsync();

            foreach (var appUser in users) {
                var role = await _userManager.GetRolesAsync(appUser);
                rolesDict.Add(appUser.Email, role.FirstOrDefault());
            }
            return rolesDict;
        }

        public async Task<IList<ApplicationUser>> GetAllUsersAsync() {
            return await _context.ApplicationUsers.ToListAsync();
        }

        public async Task<string> GetUserRoleAsync(string id) {
            var role =  await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            return role.FirstOrDefault().ToString();
        }

        public ApplicationUser GetUserById(string id) {
            return  _context.ApplicationUsers.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task<IList<IdentityUser>> GetAllMentorsAsync()
        {
            return await _userManager.GetUsersInRoleAsync("Mentor");
        }

        public async Task<IList<Application>> GetAllApplicationsAsync() {
            return await _context.Application.ToListAsync();
        }

        public async Task<Dictionary<string, string>> GetAllMentorAssignmentsAsync()
        {
            var assignmentDict = new Dictionary<string, string>();
            var applications = await GetAllApplicationsAsync();

            foreach( var app in applications)
            {
                var mentorId = await _context.MentorAssignment.Where(x => x.ApplicationId == app.ApplicationId).Select(x => x.MentorId).FirstOrDefaultAsync();
                var mentor = GetUserById(mentorId);
                assignmentDict.Add(app.ApplicationId.ToString(), mentor.FullName);
            }

            return assignmentDict;
        }
        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion
    }
}
