using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository {
    public interface IRepository {

        #region CREATE Methods
        #endregion

        #region RETRIEVE Methods
        Task<IList<ApplicationUser>> GetAllUsersAsync();
        Task<Dictionary<string, string>> GetAllUserRolesAsync();

        Task<string> GetUserRoleAsync(string id);

        ApplicationUser GetUserById(string id);

        

        Application GetApplicationById(int id);
        Task<IList<Application>> GetAllApplicationsAsync();
        Task<IList<Application>> GetAllApplicationsByApplicantIdAndCompanyNameAsync(string id, string name);
        Task<Dictionary<int, int>> GetAllApplicationIterationsAsync();
        ApplicationUser GetApplicantByApplicationId(int id);
        Task<IList<IdentityUser>> GetAllApplicantsAsync();        
        Task<int> GetIterationByApplicantId(int applicationId, string applicantId);        
        ApplicationUser GetMentorByApplicationId(int id);
        Task<IList<IdentityUser>> GetAllMentorsAsync();
        Task<Dictionary<string, string>> GetAllMentorAssignmentsAsync();
        MentorAssignment GetMentorAssignmentByApplicationId(int id);

        int GetStatusIdByName(string role);

        Task<IList<string>> GetAllCompaniesByApplicantIdAsync(string id);

        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion

    }
}
