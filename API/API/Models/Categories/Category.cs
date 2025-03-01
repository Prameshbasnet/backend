using Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Categories
{
    [Table("Category", Schema ="public")]
    public class Category : BaseEntity
    {
        [Column("CategoryName", TypeName = "VARCHAR(50)")]

        public string CategoryName { get; set; }

        [Column("Description", TypeName = "VARCHAR(50)")]

        public string Description { get; set; }
    }
}
