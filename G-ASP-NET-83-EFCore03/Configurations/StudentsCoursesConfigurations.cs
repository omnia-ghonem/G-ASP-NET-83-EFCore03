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
    public class StudentsCoursesConfigurations : IEntityTypeConfiguration<StudentsCourses>
    {

        public void Configure(EntityTypeBuilder<StudentsCourses> SC)
        {


            SC.HasKey(sc => new { sc.StudentId, sc.CourseId });
            SC.Property(sc => sc.EnrollmentDate)
              .IsRequired();
            SC.Property(sc => sc.ProgressPercent)
              .IsRequired()
              .HasDefaultValue(0);
     
            SC.Property(sc => sc.Status)
              .IsRequired()
              .HasDefaultValue(Status.Active)
              .HasConversion<string>();

            SC.Property(sc => sc.FinalGrade)
              .IsRequired(false)
              .HasColumnType("decimal(18,2)");


            SC.HasOne(sc => sc.Student)
              .WithMany(s => s.StudentsCourses)
              .HasForeignKey(sc => sc.StudentId)
              .OnDelete(DeleteBehavior.Cascade);
            SC.HasOne(sc => sc.Course)
              .WithMany(c => c.StudentsCourses)
              .HasForeignKey(sc => sc.CourseId)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
