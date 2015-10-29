using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("ENTRANCE_TYPE")]
    public partial class EntranceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntranceType()
        {
            Entrance = new HashSet<Entrance>();
        }

        [Key]
        [Column("ID_ENTRANCE_TYPE", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEntranceType { get; set; }

        [Required]
        [StringLength(50)]
        [Column("NAME")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrance> Entrance { get; set; }
    }
}
