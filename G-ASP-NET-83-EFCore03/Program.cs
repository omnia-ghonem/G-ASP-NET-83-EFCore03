using G_ASP_NET_83_EFCore03.Contexts;
using G_ASP_NET_83_EFCore03.Models;
using Microsoft.EntityFrameworkCore;

namespace G_ASP_NET_83_EFCore03
{

    internal class Program
    {
        static void Main(string[] args)
        {


            // Students

            // Starting db connection

            using LearningPlatformDbContext context = new LearningPlatformDbContext();

            try
            {
                // Update-Database
                context.Database.Migrate();


                //// Seeding Students data without duplicates

                #region Seeding
                //List<Students> students = new List<Students> {
                //            new Students { FullName = "Omar Hassan", Email = "omar.student@example.com", DOB = new DateTime(2003, 2, 10) },
                //            new Students { FullName = "Nour Adel", Email = "nour.student@example.com", DOB = new DateTime(2002, 6, 4) },
                //            new Students { FullName = "Karim Mostafa", Email = "karim.student@example.com", DOB = new DateTime(2004, 1, 13) },
                //            new Students { FullName = "Hana Ahmed", Email = "hana.student@example.com", DOB = new DateTime(2003, 9, 9) },
                //            new Students { FullName = "Youssef Ali", Email = "youssef.student@example.com", DOB = new DateTime(2002, 11, 22) }

                //    };
                //AdditionalContext.AddInitialData(context, students);

                //List<StudentsCourses> studentsCourses = new List<StudentsCourses> {
                //            new StudentsCourses { StudentId = 1, CourseId = 3, ProgressPercent = 40, Status = Status.Active, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 3)},
                //            new StudentsCourses { StudentId = 1, CourseId = 2, ProgressPercent = 70, Status = Status.Active, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 3) },
                //            new StudentsCourses { StudentId = 2, CourseId = 3, ProgressPercent = 40, Status = Status.Active, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 4) },
                //            new StudentsCourses { StudentId = 2, CourseId = 2, ProgressPercent = 0, Status = Status.Dropped, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 4) },
                //            new StudentsCourses { StudentId = 3, CourseId = 2, ProgressPercent = 80, Status = Status.Active, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 3) },
                //            new StudentsCourses { StudentId = 3, CourseId = 6, ProgressPercent = 100, Status = Status.Completed, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 3)},
                //            new StudentsCourses { StudentId = 4, CourseId = 6, ProgressPercent = 50, Status = Status.Active, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 5) },
                //            new StudentsCourses { StudentId = 5, CourseId = 6, ProgressPercent = 100, Status = Status.Completed, FinalGrade = 80, EnrollmentDate = new DateTime(2026, 10, 3) },
                //            new StudentsCourses { StudentId = 1, CourseId = 6, ProgressPercent = 0, Status = Status.Dropped, FinalGrade = 80, EnrollmentDate = new DateTime(2026, 10, 3) }
                //        };
                //AdditionalContext.AddInitialData(context, studentsCourses);
                #endregion

                #region Create

                //Console.WriteLine("============================= CREATE =============================");
                //// Add an instructor
                //Instructors instructor1 = AdditionalContext.AddRow(context, new Instructors { FullName = "Dr. Sarah Johnson", Email = "sarah.instructor@example.com", ShortBiography = "Backend instructor", DateJoined = new DateTime(2024, 3, 15) });

                //Console.WriteLine($"Instructor Generated Id: {instructor1.Id}");
                //Instructors instructor2 = AdditionalContext.AddRow(context, new Instructors { FullName = "Salma Adel", Email = "salma@example.com", ShortBiography = "Machine learning instructor", DateJoined = new DateTime(2025, 3, 15) });


                //// Add course
                //AdditionalContext.AddRow(context, new Courses { Title = "C# for Beginners", Price = 49.99m, Description = "Learn the basics of C# programming.", Level = CourseLevel.Beginner, IsPublished = true, PublishedDate = new DateTime(2026, 10, 1), CategoryId = 1, InstructorId = instructor1.Id });

                //AdditionalContext.AddRow(context, new Courses { Title = "ASP.NET Core Web API", Price = 950m, Level = CourseLevel.Intermediate, IsPublished = true, PublishedDate = new DateTime(2026, 10, 1), InstructorId = 1, CategoryId = 3 });

                //// Add 3 Students
                //AdditionalContext.AddRange(context, new List<Students>
                //{
                //    new Students { FullName = "Ali Hassan", Email = "Ali.student@example.com", DOB = new DateTime(2003, 2, 10) },
                //    new Students { FullName = "Fatima Ahmed", Email = "Fatima.student@example.com", DOB = new DateTime(2002, 5, 15) },
                //    new Students { FullName = "Omar Mohamed", Email = "Omar.student@example.com", DOB = new DateTime(2003, 8, 20) }
                //});

                //// Enroll a student in a course
                //AdditionalContext.EnrollStudentInCourse(context, new StudentsCourses { StudentId = 2, CourseId = 6, ProgressPercent = 0, Status = Status.Active, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 4) });
                //AdditionalContext.EnrollStudentInCourse(context, new StudentsCourses { StudentId = 1, CourseId = 6, ProgressPercent = 0, Status = Status.Active, FinalGrade = null, EnrollmentDate = new DateTime(2026, 10, 4) });

                #endregion

                #region Read

                //Console.WriteLine("============================= READ =============================");

                //// Find course by Id and title
                //ReadFromDb.FindCourse(context, 1, "C# Fundamentals");

                //// Filter by Price range
                //ReadFromDb.FindRange(context, 500m, 1000m);

                //// Students enrolled in a specific course
                //ReadFromDb.FindStudentsInCourse(context, 1);
                #endregion

                #region Update
                //Console.WriteLine("============================= UPDATE =============================");

                //// Update course price
                //UpdateDb.UpdateCoursePrice(context, 1, 540m);

                //// Update student course progress
                //UpdateDb.UpdateStudentCourseProgress(context, 1, 6, 100);

                //// Publish a course
                //UpdateDb.PublishCourse(context, 3);
                #endregion

                #region Delete
                //Console.WriteLine("============================= DELETE =============================");

                //// Delete an Entrollement

                //DeleteFromDb.DeleteEnrollement(context, 5, 5);

                //// Delete a course
                //// the default delete behavior is cascade, so if a course is deleted, all related enrollments will also be deleted.
                //DeleteFromDb.DeleteCourse(context, 1);

                //// Increase the price of all published courses of a specific level by a 10% 
                //BulkOerations.RaisePrice(context, CourseLevel.Advanced, 10);

                // Delete all dropped enrollments
                //BulkOerations.DeleteDroppedEnrollments(context);
                #endregion


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }



        }
    }
}
