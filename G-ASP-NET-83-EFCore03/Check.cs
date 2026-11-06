using G_ASP_NET_83_EFCore03.Contexts;
using G_ASP_NET_83_EFCore03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03
{
    static class Check
    {

        public static bool IsEntityRegistered<T>(LearningPlatformDbContext context) where T : class
        {
            return context.Model.FindEntityType(typeof(T)) != null;
        }

        public static bool IsRowExists<T>(LearningPlatformDbContext context, Func<T, bool> predicate) where T : class
        {
            if (!IsEntityRegistered<T>(context))
            {
                Console.WriteLine($"Entity type {typeof(T).Name} is not a registered EF Core entity.");
                return false;
            }
            return context.Set<T>().Any(predicate);
        }

        public static bool CanEnrollStudentInCourse(LearningPlatformDbContext context, StudentsCourses enrollment)
        {
            if (!Check.IsEntityRegistered<StudentsCourses>(context))
            {
                Console.WriteLine($"Entity type {typeof(StudentsCourses).Name} is not a registered EF Core entity.");
                return false;
            }
            if (!Check.IsRowExists<Students>(context, s => s.Id == enrollment.StudentId) || !Check.IsRowExists<Courses>(context, c => c.Id == enrollment.CourseId))
            {
                Console.WriteLine($"Can't enroll student as the specified student or course does not exist.");
                return false;
            }

            if (Check.IsRowExists<StudentsCourses>(context, sc => sc.StudentId == enrollment.StudentId && sc.CourseId == enrollment.CourseId))
            {
                Console.WriteLine($"Student with ID '{enrollment.StudentId}' is already enrolled in Course with ID '{enrollment.CourseId}'.");
                return false;
            }

            if (enrollment.ProgressPercent < 0 || enrollment.ProgressPercent > 100)
            {
                Console.WriteLine($"Invalid enrollment progress for StudentId: {enrollment.StudentId}, CourseId: {enrollment.CourseId}. It should be between 0 and 100.");
                return false;
            }
            if (enrollment.ProgressPercent == 100 && enrollment.Status != Status.Completed)

            {
                Console.WriteLine($"Invalid Status value for StudentId: {enrollment.StudentId}, CourseId: {enrollment.CourseId}. Progress 100 requires Completed status.");
                return false;
            }
            if (enrollment.ProgressPercent < 100 && enrollment.Status == Status.Completed)
            {
                Console.WriteLine($"Invalid Status value for StudentId: {enrollment.StudentId}, CourseId: {enrollment.CourseId}. Status 'Completed' requires 100% progress.");
                return false;
            }

            if (!Check.IsRowExists<Courses>(context, c => c.Id == enrollment.CourseId && c.IsPublished))
            {

                Console.WriteLine($"Course with ID '{enrollment.CourseId}' is not published. Cannot enroll student.");
                return false;
            }
            return true;
        }
    }
}
