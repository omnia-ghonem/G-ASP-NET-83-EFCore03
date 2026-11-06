using G_ASP_NET_83_EFCore03.Contexts;
using G_ASP_NET_83_EFCore03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03
{
    public static class ReadFromDb
    {

        public static void FindCourse(LearningPlatformDbContext context, int courseId, string title)
        {
            var byId = context.Courses.Find(courseId);
            Console.WriteLine(byId == null ? "Course by Id: not found." : $"By Id: {byId.Title}");
            var byTitle = context.Courses.FirstOrDefault(c => c.Title == title);
            Console.WriteLine(byTitle == null ? "Course by title: not found." : $"By title: Id={byTitle.Id}");
        }

        public static void FindRange(LearningPlatformDbContext context, decimal Firstprice, decimal Secondprice)
        {
            var coursesInRange = context.Courses.Where(c => c.Price >= Firstprice && c.Price <= Secondprice)
                                                .OrderByDescending(c => c.Price)
                                                .ToList();
            if (coursesInRange.Count == 0)
            {
                Console.WriteLine($"No courses found in the range {Firstprice} to {Secondprice}.");
            }
            else
            {
                Console.WriteLine($"Courses in the range {Firstprice} to {Secondprice}:");
                foreach (var course in coursesInRange)
                {
                    Console.WriteLine($"Title: {course.Title} Level: {course.Level} Price: {course.Price}");
                }
            }
        }


        public static void FindSubCategory(LearningPlatformDbContext context, int CategoryId)
        {
            var CategoryInDb = context.Categories.FirstOrDefault(c => c.Id == CategoryId);
            if (CategoryInDb == null)
            {
                Console.WriteLine($"Category with ID {CategoryId} not found.");
                return;
            }

            var SubCategories = context.Categories.Where(c => c.ParentCategoryId == CategoryInDb.Id).ToList();
            if (SubCategories.Count == 0)
            {
                Console.WriteLine($"No subcategories found for category '{CategoryInDb.Name}'.");
            }
            else
            {
                Console.WriteLine($"Subcategories for category '{CategoryInDb.Name}':");
                foreach (var subCategory in SubCategories)
                {
                    Console.WriteLine($"- Id: {subCategory.Id}, Name: {subCategory.Name}");
                }
            }

            var topCategories = context.Categories.Where(c => c.ParentCategoryId == null).ToList();
            Console.WriteLine("Top-level categories:");

            foreach (var category in topCategories)
            {
                Console.WriteLine(category.Name);

            }
        }   


        public static void FindStudentsInCourse(LearningPlatformDbContext context, int courseId)
        {

            var courseInDb = context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (courseInDb == null)
            {
                Console.WriteLine($"Course with ID {courseId} not found.");
                return;
            }   

           var StudentsInCourse = context.StudentsCourses.Where(sc => sc.CourseId == courseId)
                                                         .Select(sc => sc.StudentId)
                                                         .ToList();

            if (StudentsInCourse.Count == 0)
            {
                Console.WriteLine($"No students found enrolled in course with ID {courseId}.");
                return;
            }
            else
            {
                Console.WriteLine($"There are {StudentsInCourse.Count} students enrolled in course '{courseInDb.Title}':");
            }

            var StudentsInCourseDetails = context.Students.Where(s => StudentsInCourse.Contains(s.Id)).ToList();
           
            Console.WriteLine($"Students enrolled in course with ID {courseId}:");

            foreach (var student in StudentsInCourseDetails)
            {
                Console.WriteLine($"- Id: {student.Id}, Name: {student.FullName}, Email: {student.Email}");
            }
            
        }
    } 
}
