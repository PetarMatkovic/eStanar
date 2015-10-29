using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("STRUCTURE_PART_TYPE")]
    public partial class StructurePartType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StructurePartType()
        {
            StructurePart = new HashSet<StructurePart>();
        }

        [Key]
        [Column("ID_STRUCTURE_PART_TYPE", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStructurePartType { get; set; }

        [Required]
        [StringLength(50)]
        [Column("NAME")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StructurePart> StructurePart { get; set; }
    }
}
