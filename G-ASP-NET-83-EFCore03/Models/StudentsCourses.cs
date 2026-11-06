using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03.Models
{

    public enum Status
    {
        Active,
        Completed,
        Dropped
    }
    public class StudentsCourses
    {

        // Foreign Key Properties For Many to Many Relationship (StudentId, CourseId)
        // Navigation Properties For Many to Many Relationship (Students, Courses)
        // Composite Primary Key (StudentId, CourseId)
        public int StudentId { get; set; }

        public Students Student { get; set; }

        public int CourseId { get; set; }

        public Courses Course { get; set; }


        // Additional Properties For Many to Many Relationship (EnrollmentDate, FinalGrade, ProgressPercent, Status)
        public DateTime EnrollmentDate { get; set; }

        public decimal? FinalGrade { get; set; }

        public int ProgressPercent { get; set; } // 0..100: checked in Program

        public Status Status { get; set; }
    }
}
