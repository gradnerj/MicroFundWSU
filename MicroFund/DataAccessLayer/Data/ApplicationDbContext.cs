using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AwardScorecard>()
                .HasKey(c => new { c.PitchId, c.ApplicationUserId });
            modelBuilder.Entity<PitchScorecard>()
                .HasKey(c => new { c.PitchId, c.ApplicationUserId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public DbSet<ApplicationScorecard> ApplicationScorecard { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AwardScorecard> AwardScorecard { get; set; }
        public DbSet<BusinessModelAnalysis> BusinessModelAnalysis { get; set; }
        public DbSet<Demographic> Demographic { get; set; }
        public DbSet<ExternalFunding> ExternalFunding { get; set; }
        public DbSet<FollowUp> FollowUp { get; set; }
        public DbSet<GrantPhase> GrantPhase { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
        public DbSet<Pitch> Pitch { get; set; }
        public DbSet<PitchScorecard> PitchScorecard { get; set; }
    }
}
