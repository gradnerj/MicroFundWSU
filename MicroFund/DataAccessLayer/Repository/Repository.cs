﻿using DataAccessLayer.Data;
using DataAccessLayer.Migrations;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
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
            return await _context.Application.Include(x => x.ApplicationStatus).ToListAsync();
        }

        public async Task<Dictionary<string, string>> GetAllMentorAssignmentsAsync()
        {
            var assignmentDict = new Dictionary<string, string>();
            var applications = await GetAllApplicationsAsync();

            foreach( var app in applications)
            {
                var mentorId = await _context.MentorAssignment.Where(x => x.ApplicationId == app.ApplicationId).Select(x => x.MentorId).FirstOrDefaultAsync();
                if(mentorId != null) 
                {
                    ApplicationUser mentor = new ApplicationUser();
                    mentor = GetUserById(mentorId);
                    assignmentDict.Add(app.ApplicationId.ToString(), mentor.FullName);
                } else
                {
                    assignmentDict.Add(app.ApplicationId.ToString(), "unassigned");
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

        public async Task<int> GetIterationByApplicantId(int applicationId, string applicantId)
        {
            List<Application> applicationList = new List<Application>();
            applicationList = await _context.Application.Where(x => x.ApplicantId == applicantId).ToListAsync();
            var application = GetApplicationById(applicationId);
            return applicationList.IndexOf(application) + 1;
        }

        public async Task<IList<Application>> GetAllApplicationsByApplicantIdAndCompanyNameAsync(string id, string name)
        {
            return await _context.Application.Where(x => x.ApplicantId.Equals(id) && x.CompanyName.Equals(name)).OrderBy(x => x.ApplicationCreationDate).ToListAsync();
        }

        public async Task<IList<string>> GetAllCompaniesByApplicantIdAsync(string id)
        {
            return await _context.Application.Where(x => x.ApplicantId.Equals(id)).Select(x => x.CompanyName).Distinct().ToListAsync();
        }

        public async Task<IList<IdentityUser>> GetAllApplicantsAsync()
        {
            return await _userManager.GetUsersInRoleAsync("Applicant");
        }

        public async Task<Dictionary<int, int>> GetAllApplicationIterationsAsync()
        {
            var iterationsDict = new Dictionary<int, int>();
            List<IdentityUser> applicants = (List<IdentityUser>)await GetAllApplicantsAsync();

            foreach (var user in applicants)
            {

                var userCompanies = await GetAllCompaniesByApplicantIdAsync(user.Id);

                foreach(var company in userCompanies)
                {
                    var userApplications = await GetAllApplicationsByApplicantIdAndCompanyNameAsync(user.Id, company);

                    foreach (var app in userApplications)
                    {
                        iterationsDict.Add(app.ApplicationId, await GetIterationByApplicantId(app.ApplicationId, user.Id));
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

        public int GetStatusIdByName(string role)
        {
            return _context.ApplicationStatus.Where(x => x.StatusDescription.Equals(role)).Select(x => x.ApplicationStatusId).FirstOrDefault();
        }

        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion
    }
}
