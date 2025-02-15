using Common.Data.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Feedbacks
{
    [Table("Feedback", Schema = "")]
    public class Feedback : BaseEntity
    {
        [Column("Name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Column("Email", TypeName = "varchar(100)")]
        public string? Email { get; set; }

        [Column("Message", TypeName = "varchar(500)")]
        public string Message { get; set; }
    }
}
