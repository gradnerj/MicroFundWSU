using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore.Internal;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Utility
{
    /*
     * Seeds the database with initial data
     */
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.QuestionCategory.Any())
            {
                return;
            }

            var questionCategories = new QuestionCategory[]
            {
                new QuestionCategory{ QuestionCategoryDescription = "Application Questions", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false},
                new QuestionCategory{ QuestionCategoryDescription = "Business Model Analysis Questions", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false},
                new QuestionCategory{ QuestionCategoryDescription = "Followup Questions", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false}
            };

            context.QuestionCategory.AddRange(questionCategories);
            context.SaveChanges();

            //get questioncategoryid for adding new questions that are application questions
            var appQuestionCategoryId = questionCategories.Single(c => c.QuestionCategoryDescription == "Application Questions").QuestionCategoryId;

            var questions = new Question[]
            {
                new Question{QuestionDescription = "Company name", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId },
                new Question{QuestionDescription = "Status of business", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Started date", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Industry", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Product service description", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Website(URL)", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Prototype file", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Intellectual property description", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Sales description", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Has external funding", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Market opportunity", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Target market demographic", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Project sales description", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Competition description", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Team description", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Amount requested", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Plan for funds", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Previous Micro Fund recipient", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Heard about Micro Fund", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Have attended Micro Fund Workshop", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "One Million Cups experience", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Small Business Development Center Counselor Description", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId}
            };

            context.Question.AddRange(questions);
            context.SaveChanges();

            var addressTypes = new AddressType[]
            {
                new AddressType{AddressTypeDescription = "Residential", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false },
                new AddressType{AddressTypeDescription = "Business", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false}
            };

            context.AddressType.AddRange(addressTypes);
            context.SaveChanges();

            var contactTypes = new ContactType[]
            {
                new ContactType{ContactTypeDescription = "Cell Phone", UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false}
            };

            context.ContactType.AddRange(contactTypes);
            context.SaveChanges();
        }
    }
}
