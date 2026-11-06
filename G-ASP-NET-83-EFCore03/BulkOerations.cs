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
    public static class BulkOerations 
    {
        public static void RaisePrice(LearningPlatformDbContext context, CourseLevel level, decimal IncPercent)
        {
            if (!Check.IsEntityRegistered<Courses>(context))
            {
                Console.WriteLine($"Entity type {typeof(Courses).Name} is not a registered EF Core entity.");
                return;
            }

            var UpdatedPriceCount = context.Courses.Where(c => c.Level == level && c.IsPublished)
                                             .ExecuteUpdate(s => s.SetProperty(c => c.Price, c => c.Price * (1 + IncPercent / 100)));
            Console.WriteLine($"There are {UpdatedPriceCount} updated courses of level {level} by increasing price by {IncPercent}%.");

        }

        public static void DeleteDroppedEnrollments(LearningPlatformDbContext context)
        {
            if (!Check.IsEntityRegistered<Courses>(context))
            {
                Console.WriteLine($"Entity type {typeof(Courses).Name} is not a registered EF Core entity.");
                return;
            }
            // store the number of rows updated
            var DeletedCount = context.StudentsCourses.Where(c => c.Status == Status.Dropped)
                                                      .ExecuteDelete();
            Console.WriteLine($"There are {DeletedCount} dropped enrollments.");
        }

    }
}
