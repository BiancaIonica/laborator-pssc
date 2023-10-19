using Tema.Domain.Models;
using static Tema.Domain.Models.ShoppingCarPublishedEvent;
using static Tema.Domain.ExamGradesOperation;
using System;
using static Tema.Domain.Models.ExamGrades;

namespace Tema.Domain
{
    public class PublishProductWorkflow
    {
        public IExamGradesPublishedEvent Execute(PublishProductsCommand command, Func<StudentRegistrationNumber, bool> checkStudentExists)
        {
            UnvalidatedExamGrades unvalidatedGrades = new UnvalidatedExamGrades(command.InputExamGrades);
            IExamGrades grades = ValidateExamGrades(checkStudentExists, unvalidatedGrades);
            grades = CalculateFinalGrades(grades);
            grades = PublishExamGrades(grades);

            return grades.Match(
                    whenUnvalidatedExamGrades: unvalidatedGrades => new ExamGradesPublishFaildEvent("Unexpected unvalidated state") as IExamGradesPublishedEvent,
                    whenInvalidatedExamGrades: invalidGrades => new ExamGradesPublishFaildEvent(invalidGrades.Reason),
                    whenValidatedExamGrades: validatedGrades => new ExamGradesPublishFaildEvent("Unexpected validated state"),
                    whenCalculatedExamGrades: calculatedGrades => new ExamGradesPublishFaildEvent("Unexpected calculated state"),
                    whenPublishedExamGrades: publishedGrades => new ExamGradesPublishScucceededEvent(publishedGrades.Csv, publishedGrades.PublishedDate)
                );
        }
    }
}
