using API.Models.Foods;
using Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Stocks
{
    [Table("Stocks", Schema ="public")]
    public class Stock : BaseEntity
    {
        [Column("FoodId", TypeName = "uuid")]
        public Guid FoodId { get; set; }

        [ForeignKey("FoodId")]
        public Food Food { get; set; }

        [Column("Quantity", TypeName = "INTEGER")]
        public int Quantity { get; set; }

        [Column("IsAvailable", TypeName = "boolean")]
        public bool? IsAvailable { get; set; }
    }
}
