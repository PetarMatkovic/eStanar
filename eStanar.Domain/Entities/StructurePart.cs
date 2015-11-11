using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("StructurePart")]
    public partial class StructurePart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StructurePart()
        {
            Occupant = new HashSet<Occupant>();
            Owner = new HashSet<Owner>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStructurePart { get; set; }

        [Column(TypeName = "numeric")]
        public int IdStructurePartType { get; set; }

        [Column(TypeName = "numeric")]
        public int IdEntrance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AreaInSquareMeters { get; set; }

        public virtual Entrance Entrance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Occupant> Occupant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Owner> Owner { get; set; }

        public virtual StructurePartType StructurePartType { get; set; }
    }
}
