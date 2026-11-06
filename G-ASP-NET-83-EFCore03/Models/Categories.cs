using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ASP_NET_83_EFCore03.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        // Subcategory can have one parent category
        // Many-to-one relationship: Many subcategories can belong to one parent category
        // Foreign key property for the ParentCategory
        public int? ParentCategoryId { get; set; }

        public Categories? ParentCategory { get; set; }

        // Category can have many subcategories
        // one-to-many relationship: One category can have many subcategories
        public ICollection<Categories> SubCategories { get; set; } = new List<Categories>();


        // Category can have many courses
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
