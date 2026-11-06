using G_ASP_NET_83_EFCore03.Contexts;
using G_ASP_NET_83_EFCore03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03
{
    public static class UpdateDb
    {

        public static  Courses UpdateCoursePrice(LearningPlatformDbContext context, int CourseId, decimal newPrice)
        {

            if (!Check.IsEntityRegistered<Courses>(context))
            {
                Console.WriteLine($"Entity type {typeof(Courses).Name} is not a registered EF Core entity.");
                return null;
            }
            if (newPrice < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return null;
            }
            var course = context.Courses.Find(CourseId);
            if (course == null)
            {
                Console.WriteLine("Course is not found.");
                return null;
            }

            if (course.Price == newPrice)
            {
                Console.WriteLine("The new price is the same as the current price. No update needed.");
                return course;
            }
            var oldPrice = course.Price;
            course.Price = newPrice;
            context.Update(course);
            context.SaveChanges();
            Console.WriteLine($"Price changed from {oldPrice} to {newPrice}");
            return course;
        }   


        public static Courses PublishCourse(LearningPlatformDbContext context, int CourseId)
        {
            if (!Check.IsEntityRegistered<Courses>(context))
            {
                Console.WriteLine($"Entity type {typeof(Courses).Name} is not a registered EF Core entity.");
                return null;
            }


            var course = context.Courses.Find(CourseId);
            if (course == null)
            {
                Console.WriteLine("Course is not found.");
                return null;
            }
            if (course.IsPublished)
            {
                Console.WriteLine("The course is already published. No update needed.");
                return course;
            }
            course.IsPublished = true;
            course.PublishedDate = DateTime.Now;
            context.Update(course);
            context.SaveChanges();
            Console.WriteLine($"Course '{course.Title}' has been published on {course.PublishedDate}");
            return course;
        }
        public static StudentsCourses UpdateStudentCourseProgress(LearningPlatformDbContext context, int StudentId, int CourseId, int newProgressPercent)
        {
            if (!Check.IsEntityRegistered<StudentsCourses>(context))
            {
                Console.WriteLine($"Entity type {typeof(StudentsCourses).Name} is not a registered EF Core entity.");
                return null;
            }
            if (newProgressPercent < 0 || newProgressPercent > 100)
            {
                Console.WriteLine("Progress percent must be between 0 and 100.");
                return null;
            }

            var enrolledStudent = context.StudentsCourses.Find(StudentId, CourseId);
            if(enrolledStudent == null)
            {
                Console.WriteLine("Student is not enrolled in the specified course.");
                return null;
            }
            var oldProgress = enrolledStudent.ProgressPercent;

            enrolledStudent.ProgressPercent = newProgressPercent;

            if (newProgressPercent == 100)
            {
                enrolledStudent.Status = Status.Completed;
            }
            else if (newProgressPercent == 0)
            {
                enrolledStudent.Status = Status.Dropped;
            }
            else if (newProgressPercent < 100)
            {
                enrolledStudent.Status = Status.Active;
            }
      

            context.Update(enrolledStudent);
            context.SaveChanges();
            Console.WriteLine($"Progress percent changed from {oldProgress} to {newProgressPercent}");
            return enrolledStudent;
        }
    }
}
