using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }

        /*
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<AwardScorecard>()
                        .HasKey(c => new { c.PitchId, c.ApplicationUserId });
                    modelBuilder.Entity<PitchScorecard>()
                        .HasKey(c => new { c.PitchId, c.ApplicationUserId });
                    base.OnModelCreating(modelBuilder);
                }*/
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatus { get; set; }
        public DbSet<AwardHistory> AwardHistory { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<Expenditure> Expenditure { get; set; }
        public DbSet<ExternalFunding> ExternalFunding { get; set; }
        public DbSet<FollowUp> FollowUp { get; set; }
        public DbSet<FollowUpType> FollowUpType { get; set; }
        public DbSet<MentorAssignment> MentorAssignment { get; set; }
        public DbSet<MentorNote> MentorNote { get; set; }
        public DbSet<Pitch> Pitch { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionCategory> QuestionCategory { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<ScoreCard> ScoreCard { get; set; }
        public DbSet<ScoreCardField> ScoreCardField { get; set; }
        public DbSet<ScoringCategory> ScoringCategory { get; set; }
        public DbSet<PitchEvent> PitchEvents { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}
