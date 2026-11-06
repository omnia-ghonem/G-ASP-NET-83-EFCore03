using G_ASP_NET_83_EFCore03.Contexts;
using G_ASP_NET_83_EFCore03.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03
{
    static class AdditionalContext
    {
        public static void AddInitialData(LearningPlatformDbContext context, List<Students> data) 
        {

            if (!Check.IsEntityRegistered<Students>(context))
            {
                Console.WriteLine($"Entity type {typeof(Students).Name} is not a registered EF Core entity.");
                return;
            }
            Console.WriteLine($"Type: {typeof(Students)} Name: {typeof(Students).Name}");

            if (!context.Students.Any())
            {
                context.Students.AddRange(data);
                context.SaveChanges();
                Console.WriteLine($"Inserted initial {data.Count} records for {typeof(Students).Name} Table.");
            }
            else
            {
                Console.WriteLine($"{typeof(Students).Name} already contains records in the database.");
            }
        }
        public static void AddInitialData(LearningPlatformDbContext context, List<StudentsCourses> enrollment) 
        {

            Console.WriteLine($"Type: {typeof(StudentsCourses)} Name: {typeof(StudentsCourses).Name}");

            foreach (var sc in enrollment)
            {
                if (!Check.CanEnrollStudentInCourse(context, sc))
                {
                    return;
                }

            }

            if (!context.StudentsCourses.Any())
            {
                context.StudentsCourses.AddRange(enrollment);
                context.SaveChanges();
                Console.WriteLine($"Inserted initial {enrollment.Count} records for {typeof(StudentsCourses).Name} Table.");
            }
            else
            {
                Console.WriteLine($"{typeof(StudentsCourses).Name} already contains records in the database.");
            }
        }

        public static Instructors AddRow(LearningPlatformDbContext context, Instructors Instructor)
        {
            if (!Check.IsEntityRegistered<Instructors>(context))
            {
                Console.WriteLine($"Entity type {typeof(Instructors).Name} is not a registered EF Core entity.");
                return null;
            }
            if (Check.IsRowExists<Instructors>(context, i => i.Email == Instructor.Email))
            {
                Console.WriteLine($"Record already exists in {typeof(Instructors).Name} Table.");
                return context.Instructors.FirstOrDefault(i => i.Email == Instructor.Email);
            }
            else
            {
                context.Instructors.Add(Instructor);
                context.SaveChanges();
                Console.WriteLine($"Inserted a new record for {typeof(Instructors).Name} Table.");
                return Instructor;
            }

        }

        public static Courses AddRow(LearningPlatformDbContext context, Courses course)
        {
            if (!Check.IsEntityRegistered<Courses>(context))
            {
                Console.WriteLine($"Entity type {typeof(Courses).Name} is not a registered EF Core entity.");
                return null;
            }
            // var existingCourse = context.Courses.FirstOrDefault(c => c.Title == course.Title);
            if (!Check.IsRowExists<Instructors>(context, i => i.Id == course.InstructorId)  || !Check.IsRowExists<Categories>(context, c => c.Id == course.CategoryId))
            {
                Console.WriteLine($"Can't add course as the specified instructor or category does not exist.");
                return null;
            }

            if (Check.IsRowExists<Courses>(context, c => c.Title == course.Title)) 
            {
                Console.WriteLine($"Course with title '{course.Title}' already exists in the Courses Table.");
                return context.Courses.FirstOrDefault(c => c.Title == course.Title);
            }
            else
            {
                context.Courses.Add(course);
                context.SaveChanges();
                Console.WriteLine($"Inserted a new course '{course.Title}' into the Courses Table.");
                return course;
            }

           
        }


        public static List<Students> AddRange (LearningPlatformDbContext context, List<Students> students)
        {

            if (!Check.IsEntityRegistered<Students>(context))
            {
                Console.WriteLine($"Entity type {typeof(Students).Name} is not a registered EF Core entity.");
                return null;
            }

            foreach (var student in students)
            {
                if (Check.IsRowExists<Students>(context, s => s.Id == student.Id))
                {
                    return null;
                }

            }

            context.Students.AddRange(students);
            context.SaveChanges();
            Console.WriteLine($"Inserted initial {students.Count} records for {typeof(Students).Name} Table.");
            return students;


        }

        public static void EnrollStudentInCourse(LearningPlatformDbContext context, StudentsCourses enrollment)
        {
            if (!Check.CanEnrollStudentInCourse(context, enrollment))
            {
                return;
            }

            context.StudentsCourses.Add(enrollment);
            context.SaveChanges();
            Console.WriteLine($"Enrolled Student with ID '{enrollment.StudentId}' in Course with ID '{enrollment.CourseId}'.");
           
        }
    }
}
