using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("STRUCTURE")]
    public partial class Structure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Structure()
        {
            Document = new HashSet<Document>();
            Entrance = new HashSet<Entrance>();
            Notice = new HashSet<Notice>();
            Representative = new HashSet<Representative>();
        }

        [Key]
        [Column("ID_STRUCTURE", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStructure { get; set; }

        [Column("ID_STRUCTURE_TYPE", TypeName = "numeric")]
        public int IdStructureType { get; set; }

        [Column("ID_CITY", TypeName = "numeric")]
        public int IdCity { get; set; }

        [Column("NUMBER_OF_FLOORS", TypeName = "numeric")]
        public int NumberOfFloors { get; set; }

        [Required]
        [StringLength(250)]
        [Column("ADDRESS")]
        public string Address { get; set; }

        [StringLength(250)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrance> Entrance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notice> Notice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Representative> Representative { get; set; }

        public virtual StructureType StructureType { get; set; }
    }
}
