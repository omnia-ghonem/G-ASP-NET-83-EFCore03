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
    public class InstructorsConfigurations : IEntityTypeConfiguration<Instructors>
    {
        public void Configure(EntityTypeBuilder<Instructors> I)
        {
            I.HasKey(i => i.Id);
            I.Property(i => i.Id)
             .UseIdentityColumn(1,1);
            I.Property(i => i.FullName)
             .IsRequired()
             .HasMaxLength(100);
            I.Property(i => i.Email)
             .IsRequired()
             .HasMaxLength(100);
            I.Property(i => i.ShortBiography)
             .IsRequired(false)
             .HasMaxLength(200);
            I.Property(i => i.DateJoined)
             .IsRequired();

            I.HasData(
                    new Instructors { Id = 1, FullName = "Mona Ali", Email = "mona@example.com", ShortBiography = "Backend instructor", DateJoined = new DateTime(2025, 1, 10) },
                    new Instructors { Id = 2, FullName = "Ahmed Samir", Email = "ahmed@example.com", ShortBiography = "Web development instructor", DateJoined = new DateTime(2025, 2, 12) },
                    new Instructors { Id = 3, FullName = "Salma Adel", Email = "salma@example.com", ShortBiography = "Machine learning instructor", DateJoined = new DateTime(2025, 3, 15) }

                      );
        }

    }
}
