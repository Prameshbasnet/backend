using API.Models.Categories;
using Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Foods
{
    [Table("Foods", Schema ="public")]
    public class Food : BaseEntity
    {
        [Column("Name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [Column("Description", TypeName = "VARCHAR(50)")]

        public string Description { get; set; }

        [Column("Price", TypeName = "VARCHAR(50)")]
        public decimal Price { get; set; }

        [Column("ImageUrl", TypeName = "VARCHAR(150)")]

        public string ImageUrl { get; set; }

        [Column("CategoryId", TypeName = "uuid")]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
