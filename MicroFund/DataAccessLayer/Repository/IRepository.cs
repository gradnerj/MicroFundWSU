﻿using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository {
    public interface IRepository {

        #region CREATE Methods
        #endregion

        #region RETRIEVE Methods
        Task<IList<ApplicationUser>> GetAllUsersAsync();
        Task<Dictionary<string, string>> GetUsersByRoleAsync(string roleName);
        Task<Dictionary<string, string>> GetAllUserRolesAsync();

        Task<IList<string>> GetUserRolesAsync(string id);

        ApplicationUser GetUserById(string id);

        

        Application GetApplicationById(int id);
        Task<IList<Application>> GetAllApplicationsToAssignAsync();
        Task<IList<Application>> GetAllApplicationsAsync();
        Task<Dictionary<int, int>> GetAllApplicationIterationsAsync();
        ApplicationUser GetApplicantByApplicationId(int id);            
        Task<int> GetIteration(int applicationId, string applicantId, string companyName);        
        ApplicationUser GetMentorByApplicationId(int id);
        Task<IList<IdentityUser>> GetAllMentorsAsync();
        Task<Dictionary<string, string>> GetAllMentorAssignmentsAsync();
        List<MentorAssignment> GetAllMentorAssignmentsByMentorId(string mentorId);
        MentorAssignment GetMentorAssignmentByApplicationId(int id);
        int GetStatusIdByName(string status);
        Task<IList<MentorNote>> GetMentorNotes(string mentorId, int mentorAssignmentId);
        List<MentorAssignment> GetCurrentMentorAssignments(string mentorId);
        Task<IList<Application>> GetAllApplicationsByApplicationUserId(string id);
        Task<Dictionary<int, int>> GetMentorAssignmentIterationPairsAsync(List<MentorAssignment> list);

        Task<IList<PitchEvent>> GetAllPitchEventsAsync();
        Task<IList<Pitch>> GetAllPitchesAsync();


        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion

    }
}
