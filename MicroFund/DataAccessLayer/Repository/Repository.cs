using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
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
        public async Task<Dictionary<string, string>> GetUsersByRoleAsync(string roleName)
        {
            var rolesDict = new Dictionary<string, string>();
            var users = await GetAllUsersAsync();

            foreach (var appUser in users)
            {
                var role = await _userManager.GetRolesAsync(appUser);
                if (role.FirstOrDefault() == roleName)
                { rolesDict.Add(appUser.Email, role.FirstOrDefault()); }
            }
            return rolesDict;
        }

        public async Task<IList<ApplicationUser>> GetAllUsersAsync() {
            return await _context.ApplicationUsers.ToListAsync();
        }

        public async Task<IList<string>> GetUserRolesAsync(string id) {
            var roles =  await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            return roles;
        }

        public ApplicationUser GetUserById(string id) {
            return  _context.ApplicationUsers.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task<IList<IdentityUser>> GetAllMentorsAsync()
        {
            return await _userManager.GetUsersInRoleAsync("Mentor");
        }

        public async Task<IList<Application>> GetAllApplicationsAsync() {
            return await _context.Application.Include(x => x.ApplicationStatus).ToListAsync();
        }

        public async Task<IList<Application>> GetAllApplicationsToAssignAsync()
        {
            return await _context.Application.Where(x => x.ApplicationStatusId > 3).Include(x => x.ApplicationStatus).OrderBy(x => x.ApplicationStatusId).ThenBy(x => x.CompanyName).ToListAsync();
        }

        public async Task<Dictionary<string, string>> GetAllMentorAssignmentsAsync()
        {
            var assignmentDict = new Dictionary<string, string>();
            //var applications = await GetAllApplicationsAsync();
            var applications = await _context.Application.Where(x => x.ApplicationStatusId > 3).ToListAsync();

            foreach ( var app in applications)
            {
                var mentorId = await _context.MentorAssignment.Where(x => x.ApplicationId == app.ApplicationId).Select(x => x.MentorId).FirstOrDefaultAsync();
                if(mentorId != null) 
                {
                    ApplicationUser mentor = new ApplicationUser();
                    mentor = GetUserById(mentorId);
                    assignmentDict.Add(app.ApplicationId.ToString(), mentor.FullName);
                } else
                {
                    assignmentDict.Add(app.ApplicationId.ToString(), "");
                }
                
            }

            return assignmentDict;
        }

        public Application GetApplicationById(int id)
        {
            return _context.Application.Where(x => x.ApplicationId == id).Include(x => x.ApplicationStatus).FirstOrDefault();
        }

        public ApplicationUser GetMentorByApplicationId(int id)
        {
            var mentorId = _context.MentorAssignment.Where(x => x.ApplicationId == id).Select(x => x.MentorId).FirstOrDefault();
            return GetUserById(mentorId);
        }

        public async Task<int> GetIteration(int applicationId, string applicantId, string companyName)
        {
            List<Application> applicationList = new List<Application>();
            applicationList = await _context.Application.Where(x => x.ApplicantId == applicantId && x.CompanyName.Equals(companyName)).ToListAsync();
            var application = GetApplicationById(applicationId);
            return applicationList.IndexOf(application) + 1;
        }

        public async Task<Dictionary<int, int>> GetAllApplicationIterationsAsync()
        {
            var iterationsDict = new Dictionary<int, int>();
            List<IdentityUser> applicants = (List<IdentityUser>)await _userManager.GetUsersInRoleAsync("Applicant");

            foreach (var user in applicants)
            {

                var userCompanies = await _context.Application.Where(x => x.ApplicantId.Equals(user.Id)).Select(x => x.CompanyName).Distinct().ToListAsync();

                foreach (var company in userCompanies)
                {
                    var userApplications = await _context.Application.Where(x => x.ApplicantId.Equals(user.Id) && x.CompanyName.Equals(company)).OrderBy(x => x.ApplicationCreationDate).ToListAsync();

                    foreach (var app in userApplications)
                    {
                        iterationsDict.Add(app.ApplicationId, await GetIteration(app.ApplicationId, user.Id, company));
                    }
                }
                
                

            }

            return iterationsDict;
        }

        public MentorAssignment GetMentorAssignmentByApplicationId(int id)
        {
            return _context.MentorAssignment.Where(x => x.ApplicationId == id).FirstOrDefault();
        }

        public ApplicationUser GetApplicantByApplicationId(int id)
        {
            var application = _context.Application.Where(x => x.ApplicationId == id).FirstOrDefault();
            return _context.ApplicationUsers.Where(x => x.Id.Equals(application.ApplicantId)).FirstOrDefault();
        }

        public int GetStatusIdByName(string status)
        {
            return _context.ApplicationStatus.Where(x => x.StatusDescription.Equals(status)).Select(x => x.ApplicationStatusId).FirstOrDefault();
        }        

        public async Task<IList<MentorNote>> GetMentorNotes(string mentorId)
        {
            //get mentor notes only assigned to mentor
            var mentorAssignment = GetAllMentorAssignmentsByMentorId(mentorId);
            var mentorAssignmentIds = mentorAssignment.Select(x => x.MentorAssignmentId).ToList();
            return await _context.MentorNote.Where(x => mentorAssignmentIds.Contains(x.MentorAssignmentId) && !x.IsArchived).Include(x => x.MentorAssignment).ThenInclude(x => x.Application).ThenInclude(x => x.ApplicationStatus).OrderBy(x => x.MentorAssignment.Application.ApplicationStatusId).ThenBy(x => x.MentorAssignment.Application.CompanyName).ThenByDescending(x => x.MeetingDate).ToListAsync();
        } 

        public List<MentorAssignment> GetAllMentorAssignmentsByMentorId(string mentorId)
        {
            return _context.MentorAssignment.Where(x => x.MentorId.Equals(mentorId)).Include(x => x.Application).ToList();
        }

        public List<MentorAssignment> GetCurrentMentorAssignments(string mentorId)
        {
            return _context.MentorAssignment.Where(x => x.MentorId.Equals(mentorId) && x.Application.ApplicationStatus.StatusDescription.Equals("Assigned to Mentor")).Include(x => x.Application).ToList();
        }

        
        public async Task<IList<Application>> GetAllApplicationsByApplicationUserId(string id)
        {
            return await _context.Application.Where(x => x.ApplicantId == id).Include(x => x.ApplicationStatus).ToListAsync();
        }



        public async Task<IList<PitchEvent>> GetAllPitchEventsAsync()
        {
            return await _context.PitchEvents.ToListAsync();
        }

        public async Task<IList<Pitch>> GetAllPitchesAsync()
        {
            return await _context.Pitch.ToListAsync();
        }


        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion
    }
}
