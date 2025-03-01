using Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Tables
{
    [Table("Tables", Schema = "public")]
    public class Table : BaseEntity
    {
        [Column("TableName", TypeName = "VARCHAR(50)")]
        public string TableName { get; set; }

        [Column("TableNumber", TypeName = "INTEGER")]
        public int TableNumber { get; set; }

        [Column("Capacity", TypeName = "INTEGER")]
        public int Capacity { get; set; }

        [Column("Status", TypeName = "VARCHAR(50)")]
        public string Status { get; set; }
    }
}
