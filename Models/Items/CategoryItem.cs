using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _18_1_22_Beginner_APIs.Models
{
    public class CategoryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ProductItem> Products { get; set; }
    }

    public class CategoryDBContext : DbContext
    {
        public CategoryDBContext(DbContextOptions<CategoryDBContext> options) : base(options)
        { }
        public DbSet<CategoryItem> CategoryItems { get; set; }
    }
}
