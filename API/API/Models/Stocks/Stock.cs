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

        [Column("Quantity", TypeName = "VARCHAR(50)")]
        public string Quantity { get; set; }

        [Column("IsAvailable", TypeName = "BIT")]
        public bool IsAvailable { get; set; }
    }
}
