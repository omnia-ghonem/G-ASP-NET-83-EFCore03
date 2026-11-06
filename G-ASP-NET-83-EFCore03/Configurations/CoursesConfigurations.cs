using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G_ASP_NET_83_EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_ASP_NET_83_EFCore03.Configurations
{
    public class CoursesConfigurations : IEntityTypeConfiguration<Courses>
    {

        public void Configure(EntityTypeBuilder<Courses> C)
        { 
        
            C.HasKey(c => c.Id);
            C.Property(c => c.Id)
             .UseIdentityColumn(1, 1);
            C.Property(c => c.Level)
             .IsRequired()
             .HasConversion<string>();
            C.Property(c => c.Title)
             .IsRequired()
             .HasMaxLength(100);
            C.Property(c => c.Description)
             .IsRequired(false)
             .HasMaxLength(500);
            C.Property(c => c.Price)
             .IsRequired()
             .HasColumnType("decimal(18,2)");
            C.Property(c => c.IsPublished)
             .IsRequired()
             .HasDefaultValue(false);

            C.HasOne(c => c.Instructor)
             .WithMany(i => i.Courses)
             .HasForeignKey(c => c.InstructorId)
             .OnDelete(DeleteBehavior.NoAction);

            C.HasOne(c => c.Categories)
             .WithMany(catei => catei.Courses)
             .HasForeignKey(c => c.CategoryId)
             .OnDelete(DeleteBehavior.NoAction);


            C.HasData(
                   new Courses { Id = 1, Title = "C# Fundamentals", Price = 500m, Level = CourseLevel.Beginner, IsPublished = true, PublishedDate = new DateTime(2026, 10, 1), InstructorId = 1, CategoryId = 2 },
                   new Courses { Id = 2, Title = "ASP.NET Core Web API", Price = 950m, Level = CourseLevel.Intermediate, IsPublished = true, PublishedDate = new DateTime(2026, 10, 1), InstructorId = 1, CategoryId = 3 },
                   new Courses { Id = 3, Title = "Entity Framework Core", Price = 850m, Level = CourseLevel.Intermediate, IsPublished = false, PublishedDate = null, InstructorId = 1, CategoryId = 3 },
                   new Courses { Id = 4, Title = "HTML and CSS", Price = 350m, Level = CourseLevel.Beginner, IsPublished = false, PublishedDate = null, InstructorId = 2, CategoryId = 4 },
                   new Courses { Id = 5, Title = "OOP", Price = 1100m, Level = CourseLevel.Beginner, IsPublished = false, PublishedDate = null, InstructorId = 3, CategoryId = 1 },
                   new Courses { Id = 6, Title = "Advanced C#", Price = 900m, Level = CourseLevel.Advanced, IsPublished =true, PublishedDate = new DateTime(2026, 10, 1), InstructorId =2, CategoryId = 2 }
               );
        }
    }
}
