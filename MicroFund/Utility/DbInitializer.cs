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
                new Question{QuestionDescription = "Product service description", QuestionNumber = 1, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Status of business", QuestionNumber = 2, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Started date", QuestionNumber = 3, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Sales description", QuestionNumber = 4, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Industry", QuestionNumber = 5, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Website(URL)", QuestionNumber = 6, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Prototype file", QuestionNumber = 7, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Intellectual property description", QuestionNumber = 8, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Market opportunity", QuestionNumber = 9, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Target market demographic", QuestionNumber = 10, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Project sales description", QuestionNumber = 11, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Competition description", QuestionNumber = 12, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Team description", QuestionNumber = 13, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Amount requested", QuestionNumber = 14, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Plan for funds", QuestionNumber = 15, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Previous Micro Fund recipient", QuestionNumber = 16, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Has external funding", QuestionNumber = 17, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Heard about Micro Fund", QuestionNumber = 18, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Have attended Micro Fund Workshop", QuestionNumber = 19, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "One Million Cups experience", QuestionNumber = 20, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
                    QuestionCategoryId = appQuestionCategoryId},
                new Question{QuestionDescription = "Small Business Development Center Counselor Description", QuestionNumber = 21, UpdatedBy = "superadmin@admin.com", UpdatedDate = DateTime.Now, IsArchived = false,
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
