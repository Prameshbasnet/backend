using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Data.Data
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "uuid")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("CreatedDate", TypeName="timestamp with time zone")]
        public DateTimeOffset? CreatedDate { get; set; }

        [Column("CreatedBy", TypeName ="uuid")]
        public Guid? CreatedBy { get; set; }

        [Column("ModifiedDate", TypeName ="timestamp with time zone")]
        public DateTimeOffset? ModifiedDate { get; set; }

        [Column("ModifiedBy", TypeName="uuid")]
        public Guid? ModifiedBy { get; set; }

        [Column("IsActive", TypeName ="boolean")]
        public bool IsActive { get; set; }

        [Column("IsDeleted", TypeName = "boolean")]
        public bool IsDeleted { get; set; } = false;
    }
}
