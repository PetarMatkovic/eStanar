using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("OWNER")]
    public partial class Owner
    {
        [Key]
        [Column("ID_OWNER", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOwner { get; set; }

        [Column("ID_STRUCTURE_PART", TypeName = "numeric")]
        public int IdStructurePart { get; set; }

        [Column("ID_PERSON", TypeName = "numeric")]
        public int IdPerson { get; set; }

        public virtual StructurePart StructurePart { get; set; }

        public virtual Person Person { get; set; }
    }
}
