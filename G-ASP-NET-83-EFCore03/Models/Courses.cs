using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03.Models
{
    public enum CourseLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }
    public class Courses
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public CourseLevel Level { get; set; } 

        public bool IsPublished { get; set; }

        // attribute of the relationship between Courses and Instructors
        public DateTime? PublishedDate { get; set; }

        // Many-to-one relationship: Many courses can belong to one category
        // Foreign key property for the Category
        public int CategoryId { get; set; }

        public Categories Categories { get; set; }

        // Course enrolled by many students
        public ICollection<StudentsCourses> StudentsCourses { get; set; } = new List<StudentsCourses>();

        // Many-to-one relationship: course been taught by one instructor
        // Foreign key property for the Instructor
        public int InstructorId { get; set; }

        public Instructors Instructor { get; set; }




    }
}
