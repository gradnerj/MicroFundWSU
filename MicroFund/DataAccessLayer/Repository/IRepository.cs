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
        Task<Dictionary<int, int>> GetAllApplicationIterationsAsync();
        ApplicationUser GetApplicantByApplicationId(int id);            
        Task<int> GetIteration(int applicationId, string applicantId, string companyName);        
        ApplicationUser GetMentorByApplicationId(int id);
        Task<IList<IdentityUser>> GetAllMentorsAsync();
        Task<Dictionary<string, string>> GetAllMentorAssignmentsAsync();
        MentorAssignment GetMentorAssignmentByApplicationId(int id);
        int GetStatusIdByName(string role);

        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion

    }
}
