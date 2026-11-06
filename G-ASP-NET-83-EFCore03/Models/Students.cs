using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03.Models
{
    public class Students
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public ICollection<StudentsCourses> StudentsCourses { get; set; } = new List<StudentsCourses>();
    }
}
