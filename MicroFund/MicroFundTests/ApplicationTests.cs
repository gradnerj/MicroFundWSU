using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MicroFundTests
{
    [TestClass]
    public class ApplicationTests
    {

        private IConfigurationRoot _config;
        private DbContextOptions<ApplicationDbContext> _options;
        private readonly ApplicationDbContext _context;

        public ApplicationTests()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _config = builder.Build();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_config.GetConnectionString("DefaultConnection")).Options;
            _context = new ApplicationDbContext(_options);
        }

        [TestMethod]
        public void AddApplication()
        {
            /*
            var app1 = new Application()
            {
                ApplicantId = "8a89b953-3a97-4a64-90f3-4e3061e08691",
                ApplicationStatusId = 4,
                CompanyName = "Bob's Burgers",
                ApplicationCreationDate = DateTime.Now,
                UpdatedBy = "c8fd0d0f-6360-4c55-bc82-b7f24b69130b",
                UpdatedDate = DateTime.Now,
                IsArchived = false
            };

            _context.Application.Add(app1);
            */

            var app2 = new Application()
            {
                ApplicantId = "8a89b953-3a97-4a64-90f3-4e3061e08691",
                ApplicationStatusId = 4,
                CompanyName = "Stickers for Men",
                ApplicationCreationDate = DateTime.Now,
                UpdatedBy = "c8fd0d0f-6360-4c55-bc82-b7f24b69130b",
                UpdatedDate = DateTime.Now,
                IsArchived = false
            };

            _context.Application.Add(app2);
            _context.SaveChanges();
        }
    }

    
}
