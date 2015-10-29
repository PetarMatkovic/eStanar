using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("ENTRANCE")]
    public partial class Entrance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entrance()
        {
            Document = new HashSet<Document>();
            Notice = new HashSet<Notice>();
            StructutrePart = new HashSet<StructurePart>();
        }

        [Key]
        [Column("ID_ENTRANCE", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEntrance { get; set; }

        [Column("ID_ENTRANCE_TYPE", TypeName = "numeric")]
        public int IdEntranceType { get; set; }

        [Column("ID_STRUCTURE", TypeName = "numeric")]
        public int IdStructure { get; set; }

        [StringLength(10)]
        [Column("ENTRANCE_NUMBER")]
        public string EntranceNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Document { get; set; }

        public virtual EntranceType EntranceType { get; set; }

        public virtual Structure Structure { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notice> Notice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StructurePart> StructutrePart { get; set; }
    }
}
