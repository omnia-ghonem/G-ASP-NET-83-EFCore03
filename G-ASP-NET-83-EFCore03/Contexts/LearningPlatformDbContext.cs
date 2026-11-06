using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G_ASP_NET_83_EFCore03.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Reflection;
namespace G_ASP_NET_83_EFCore03.Contexts
{
    public class LearningPlatformDbContext: DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=LearningPlatformDb;Trusted_Connection=True;TrustServerCertificate=True;");

            }
        }


        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get; set; }

    }
}
