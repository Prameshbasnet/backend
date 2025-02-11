using Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.PromoCodes
{
    [Table("PromoCode", Schema = "Promotion")]

    public class PromoCode : BaseEntity
    {
        [Column("Description", TypeName = "text")]

        public string Description { get; set; }
        [Column("Code", TypeName = "varchar(50)")]

        public string Code { get; set; }
        [Column("StartDate", TypeName = "timestamp with time zone")]

        public DateTime StartDate { get; set; }
        [Column("EndDate", TypeName = "timestamp with time zone")]

        public DateTime EndDate { get; set; }
        [Column("Amount", TypeName = "numeric")]

        public decimal Amount { get; set; }
        [Column("Type", TypeName = "varchar(10)")]

        public string Type { get; set; }

    }
}
