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
    public class CategoriesConfigurations : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> C)
        {
            C.HasKey(c => c.Id);
            C.Property(c => c.Id)
             .UseIdentityColumn(1, 1);
            C.Property(c => c.Description)
             .IsRequired()
             .HasMaxLength(500);

            C.Property(c => c.Name) 
             .IsRequired()
             .HasMaxLength(100);

            C.HasOne(catei => catei.ParentCategory)  
             .WithMany(p => p.SubCategories)
             .HasForeignKey(c => c.ParentCategoryId)
             .OnDelete(DeleteBehavior.NoAction);

            C.HasData(

            new Categories { Id = 1, Name = "Programming", Description = "Programming courses" , ParentCategoryId = null },
            new Categories { Id = 2, Name = "Backend", Description = "Backend development courses", ParentCategoryId = 1 },
            new Categories { Id = 3, Name = "ASP.NET", Description = "ASP.NET courses", ParentCategoryId = 2 },
            new Categories { Id = 4, Name = "Frontend", Description = "Frontend development courses", ParentCategoryId = 1 },
            new Categories { Id = 5, Name = "Data Science", Description = "Data science courses", ParentCategoryId = null },
            new Categories { Id = 6, Name = "Machine Learning", Description = "Machine learning courses", ParentCategoryId = 5 }

                );

 


    }
}
}
