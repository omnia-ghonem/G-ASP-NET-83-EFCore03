using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03.Models
{
    public class Instructors
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? ShortBiography { get; set; }

        public DateTime DateJoined { get; set; }


        // one-to-many relationship: Instructors can teach many courses
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
