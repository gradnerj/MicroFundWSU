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

        public DbSet<Address> Address { get; set; }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public DbSet<ApplicationScorecard> ApplicationScorecard { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<BusinessModelAnalysis> BusinessModelAnalysis { get; set; }
        public DbSet<Demographic> Demographic { get; set; }
        public DbSet<ExternalFunding> ExternalFunding { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
    }
}
