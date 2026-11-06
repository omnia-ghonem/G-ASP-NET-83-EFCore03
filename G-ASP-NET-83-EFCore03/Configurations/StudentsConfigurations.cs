using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using G_ASP_NET_83_EFCore03.Models;
namespace G_ASP_NET_83_EFCore03.Configurations
{
    public class StudentsConfigurations : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> S)
        {
            S.HasKey(s => s.Id);
            S.Property(s => s.Id)
             .UseIdentityColumn(1, 1);
            S.Property(s => s.FullName)
             .IsRequired()
             .HasMaxLength(100);
            S.Property(s => s.Email)
             .IsRequired()
             .HasMaxLength(150);
            S.HasIndex(s => s.Email)
             .IsUnique();
            S.Property(s => s.DOB)
             .IsRequired();
    
        }
    }
}
