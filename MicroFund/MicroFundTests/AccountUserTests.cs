using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using DataAccessLayer.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Repository;
using System.IO;
using System;
using System.Linq;

namespace MicroFundTests
{
    [TestClass]
    public class AccountUserTests
    {

        private IConfigurationRoot _config;
        private DbContextOptions<ApplicationDbContext> _options;
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repo;
        private UserManager<IdentityUser> _userManager;

        public AccountUserTests()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _config = builder.Build();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_config.GetConnectionString("DefaultConnection")).Options;
            _context = new ApplicationDbContext(_options);
           // _userManager = userManager;
           // _repo = new Repository(_context, _userManager);
        }

        [TestMethod]
        public void DuplicateEmails()
        {
            var user1 = new ApplicationUser()
            {
                Email = "emailunittest4@gmail.com",
                UserName = "emailunittest4@gmail.com"                
            };

            var result = _context.Users.Add(user1);
            _context.SaveChanges();

            Assert.Fail("This should fail adding duplicate user");
        }

        [TestMethod]
        public void UpdateApplicant()
        {
            var user1 = new Applicant()
            {
                CreationDate = DateTime.Now,
                FirstName = "UpdateApplicant",
                LastName = "UnitTest",
                DOB = DateTime.Now,
                HighestEduCompleted = "Some College",
                CurrentStudent = false,
                WSUEntrepreneurshipMinor = false,
                WSUEmployee = false,
                WSUNumber = "",
                Gender = "Female",
                RaceEthnicity = "Caucasion",
                Income = 100000.00f,
                ResidenceEnvironment = "Rent",
                VeteranStatus = true,
                UpdatedBy = "",
                UpdatedDate = DateTime.Now,
                IsArchived = false
            };

            _context.Applicant.Add(user1);
            _context.SaveChanges();

            var userFromDB = _context.Applicant.Where(x => x.FirstName.Equals("UpdateApplicant")).FirstOrDefault();

            user1.CreationDate = Convert.ToDateTime("11/01/2020");
            user1.FirstName = "UnitTest";
            user1.LastName = "UpdateApplicant";
            user1.DOB = Convert.ToDateTime("08/01/1995");
            user1.HighestEduCompleted = "BS";
            user1.CurrentStudent = true;
            user1.WSUEntrepreneurshipMinor = true;
            user1.WSUEmployee = true;
            user1.WSUNumber = "W1234567";
            user1.Gender = "Male";
            user1.RaceEthnicity = "American Indian";
            user1.Income = 1.00f;
            user1.ResidenceEnvironment = "Own";
            user1.VeteranStatus = false;
            user1.VeteranStatus = false;
            user1.UpdatedBy = "";
            user1.UpdatedDate = Convert.ToDateTime("11/09/2020");
            user1.IsArchived = true;

            var result = _context.Applicant.Update(user1);
            _context.SaveChanges();

            Assert.AreEqual(userFromDB, user1);

            _context.Applicant.Remove(userFromDB);
            _context.SaveChanges();

        }

        [TestMethod]
        public void DuplicateAddresses()
        {

            var addressType1 = new AddressType()
            {
                AddressTypeDescription = "TestAddressType",
                UpdatedBy = "",
                UpdatedDate = DateTime.Now,
                IsArchived = false
            };

            _context.AddressType.Add(addressType1);
            _context.SaveChanges();

            var addressTypeFromDb = _context.AddressType.Where(x => x.AddressTypeDescription.Equals("TestAddressType")).FirstOrDefault();

            var address1 = new Address()
            {
                ApplicantId = "965103f5-5f7f-4b75-8a87-4af678f1259e",
                AddressTypeId = addressTypeFromDb.AddressTypeId,
                Street = "123 Sesame Street",
                City = "Ogden",
                State = "UT",
                Zip = "84114",
                Country = "USA",
                UpdatedBy  = "",
                UpdatedDate = DateTime.Now,
                IsArchived = false
            };

            _context.Address.Add(address1);
            _context.SaveChanges();

            var addressFromDb = _context.Address.Where(x => x.Street.Equals("123 Sesame Street")).FirstOrDefault();

            var address2 = new Address()
            {
                ApplicantId = "965103f5-5f7f-4b75-8a87-4af678f1259e",
                AddressTypeId = addressTypeFromDb.AddressTypeId,
                Street = "123 Sesame Street",
                City = "Ogden",
                State = "UT",
                Zip = "84114",
                Country = "USA",
                UpdatedBy = "",
                UpdatedDate = DateTime.Now,
                IsArchived = false
            };

            var result = _context.Address.Add(address2);
            _context.SaveChanges();

            Assert.Fail("This should fail when adding duplicate address");

            _context.Address.Remove(address1);
            _context.Address.Remove(address2);
            _context.AddressType.Remove(addressType1);
            _context.SaveChanges();

        }
    }
}