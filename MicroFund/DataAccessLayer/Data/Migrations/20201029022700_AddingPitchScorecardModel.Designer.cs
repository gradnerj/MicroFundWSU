﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroFund.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201029022700_AddingPitchScorecardModel")]
    partial class AddingPitchScorecardModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Models.Address", b =>
                {
                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("ApplicantId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ApplicationDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AmountRequested")
                        .HasColumnType("real");

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompetitionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasExternalFunding")
                        .HasColumnType("bit");

                    b.Property<bool>("HaveAttendedMicroFunWorkshop")
                        .HasColumnType("bit");

                    b.Property<string>("HearAboutMicroFund")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarketOpportunity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OneMillionCupsExperience")
                        .HasColumnType("bit");

                    b.Property<string>("PlanForFunds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PreviousMicroFundRecipient")
                        .HasColumnType("bit");

                    b.Property<string>("ProductServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectedSalesDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrototypeFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallBusinessDevCenterCounselorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusOfBusiness")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetMarketDemographic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("ApplicationDetails");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ApplicationScorecard", b =>
                {
                    b.Property<int>("ApplicationDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Competition")
                        .HasColumnType("int");

                    b.Property<int>("Customers")
                        .HasColumnType("int");

                    b.Property<int>("MarketOpportunity")
                        .HasColumnType("int");

                    b.Property<int>("MarketingAndSales")
                        .HasColumnType("int");

                    b.Property<string>("Outcome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OutcomeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Team")
                        .HasColumnType("int");

                    b.HasKey("ApplicationDetailsId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ApplicationScorecard");
                });

            modelBuilder.Entity("DataAccessLayer.Models.AwardScorecard", b =>
                {
                    b.Property<int>("PitchId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BenefitToCommunity")
                        .HasColumnType("int");

                    b.Property<int>("BenefitToCompany")
                        .HasColumnType("int");

                    b.Property<int>("Diversity")
                        .HasColumnType("int");

                    b.Property<int>("FollowOnApp")
                        .HasColumnType("int");

                    b.Property<int>("Geographics")
                        .HasColumnType("int");

                    b.Property<int>("GreaterOneKRevenue")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfJobs")
                        .HasColumnType("int");

                    b.Property<int>("ProbabilityOfSuccess")
                        .HasColumnType("int");

                    b.Property<int>("Returning")
                        .HasColumnType("int");

                    b.HasKey("PitchId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("AwardScorecard");
                });

            modelBuilder.Entity("DataAccessLayer.Models.BusinessModelAnalysis", b =>
                {
                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.Property<string>("Competition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinancialProjections")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagementTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarketValidation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetCustomers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToMarketStrategy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueProp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuePropValidation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MentorId");

                    b.ToTable("BusinessModelAnalysis");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Demographic", b =>
                {
                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("AgeRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HighestLevelEducationCompleted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncomeRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MilitaryStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RaceOrEthnicity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidenceEnvironment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicantId");

                    b.ToTable("Demographic");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ExternalFunding", b =>
                {
                    b.Property<int>("ApplicationDetailsId")
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationDetailsId");

                    b.ToTable("ExternalFunding");
                });

            modelBuilder.Entity("DataAccessLayer.Models.FollowUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Exit")
                        .HasColumnType("bit");

                    b.Property<bool>("Funding")
                        .HasColumnType("bit");

                    b.Property<float>("FundingAmount")
                        .HasColumnType("real");

                    b.Property<string>("FundingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrantPhaseId")
                        .HasColumnType("int");

                    b.Property<int>("JobsAdded")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfEmployees")
                        .HasColumnType("int");

                    b.Property<bool>("Profitable")
                        .HasColumnType("bit");

                    b.Property<bool>("Response")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Revenue")
                        .HasColumnType("real");

                    b.Property<float>("SalesIncrease")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrantPhaseId");

                    b.ToTable("FollowUp");
                });

            modelBuilder.Entity("DataAccessLayer.Models.GrantPhase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agreement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("AwardDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInKindCompleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInKindUsed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MailedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PitchId")
                        .HasColumnType("int");

                    b.Property<string>("Provider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReqNumber")
                        .HasColumnType("int");

                    b.Property<float>("Requested")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PitchId");

                    b.ToTable("GrantPhase");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApprovedToPitchDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.Property<string>("MentorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfVisits")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationDetailsId");

                    b.ToTable("Mentor");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Pitch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PitchDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationDetailsId");

                    b.ToTable("Pitch");
                });

            modelBuilder.Entity("DataAccessLayer.Models.PitchScorecard", b =>
                {
                    b.Property<int>("PitchId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Competition")
                        .HasColumnType("int");

                    b.Property<int>("FinProjections")
                        .HasColumnType("int");

                    b.Property<int>("GoToStrat")
                        .HasColumnType("int");

                    b.Property<int>("ManagementTeam")
                        .HasColumnType("int");

                    b.Property<int>("MarketValid")
                        .HasColumnType("int");

                    b.Property<int>("Presentation")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TargetCustomers")
                        .HasColumnType("int");

                    b.Property<int>("ValueProp")
                        .HasColumnType("int");

                    b.HasKey("PitchId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("PitchScorecard");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Address", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.ApplicationDetails", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.ApplicationScorecard", b =>
                {
                    b.HasOne("DataAccessLayer.Models.ApplicationDetails", "ApplicationDetails")
                        .WithMany()
                        .HasForeignKey("ApplicationDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("DataAccessLayer.Models.AwardScorecard", b =>
                {
                    b.HasOne("DataAccessLayer.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Pitch", "Pitch")
                        .WithMany()
                        .HasForeignKey("PitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.BusinessModelAnalysis", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Demographic", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.ExternalFunding", b =>
                {
                    b.HasOne("DataAccessLayer.Models.ApplicationDetails", "ApplicationDetails")
                        .WithMany()
                        .HasForeignKey("ApplicationDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.FollowUp", b =>
                {
                    b.HasOne("DataAccessLayer.Models.GrantPhase", "GrantPhase")
                        .WithMany()
                        .HasForeignKey("GrantPhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.GrantPhase", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Pitch", "Pitch")
                        .WithMany()
                        .HasForeignKey("PitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Mentor", b =>
                {
                    b.HasOne("DataAccessLayer.Models.ApplicationDetails", "ApplicationDetails")
                        .WithMany()
                        .HasForeignKey("ApplicationDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Pitch", b =>
                {
                    b.HasOne("DataAccessLayer.Models.ApplicationDetails", "ApplicationDetails")
                        .WithMany()
                        .HasForeignKey("ApplicationDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.PitchScorecard", b =>
                {
                    b.HasOne("DataAccessLayer.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Pitch", "Pitch")
                        .WithMany()
                        .HasForeignKey("PitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
