using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("Occupant")]
    public partial class Occupant
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOccupant { get; set; }

        [Column(TypeName = "numeric")]
        public int IdStructurePart { get; set; }

        [Column(TypeName = "numeric")]
        public int IdPerson { get; set; }

        public virtual StructurePart StructurePart { get; set; }

        public virtual Person Person { get; set; }
    }
}
