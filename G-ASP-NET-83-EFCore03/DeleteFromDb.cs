using G_ASP_NET_83_EFCore03.Contexts;
using G_ASP_NET_83_EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03
{
    public static class DeleteFromDb
    {

        public static StudentsCourses DeleteEnrollement(LearningPlatformDbContext context, int StudentId, int CourseId)
        {
            if (!Check.IsEntityRegistered<StudentsCourses>(context))
            {
                Console.WriteLine($"Entity type {typeof(StudentsCourses).Name} is not a registered EF Core entity.");
                return null;
            }
            var enrollement = context.StudentsCourses.Find(StudentId, CourseId);

            if (enrollement == null)
            {
                Console.WriteLine("Enrollment not found.");
                return null; 
            }

            context.StudentsCourses.Remove(enrollement);
            context.SaveChanges();
            Console.WriteLine($"Enrollment for StudentId {StudentId} and CourseId {CourseId} has been deleted.");
            return enrollement;
        }


        public static Categories DeleteCategory(LearningPlatformDbContext context, int CategoryId)
        {
            if (!Check.IsEntityRegistered<Categories>(context))
            {
                Console.WriteLine($"Entity type {typeof(Categories).Name} is not a registered EF Core entity.");
                return null;
            }

            var category = context.Categories.Find(CategoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return null;
            }


            try
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                Console.WriteLine($"Category with Id {CategoryId} has been deleted.");
                return category;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");

                context.Entry(category).State = EntityState.Unchanged;
                return null;
            }

        }

        public static Courses DeleteCourse(LearningPlatformDbContext context, int CourseId)
        {
            if (!Check.IsEntityRegistered<Courses>(context))
            {
                Console.WriteLine($"Entity type {typeof(Courses).Name} is not a registered EF Core entity.");
                return null;
            }
            var course = context.Courses.Find(CourseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return null;
            }
            try
            {
                int beforeCount = context.StudentsCourses.Count(sc => sc.CourseId == CourseId);

                Console.WriteLine($"Enrollments before deletion: {beforeCount}");

                context.Courses.Remove(course);
                context.SaveChanges();
                Console.WriteLine($"Course with Id {CourseId} has been deleted.");

                int afterCount = context.StudentsCourses.Count(sc => sc.CourseId == CourseId);

                Console.WriteLine($"Enrollments after deletion: {afterCount}");
                return course;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                context.Entry(course).State = EntityState.Unchanged;
                return null;
            }
        }
    }
}
