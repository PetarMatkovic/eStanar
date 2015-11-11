using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("Owner")]
    public partial class Owner
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOwner { get; set; }

        [Column(TypeName = "numeric")]
        public int IdStructurePart { get; set; }

        [Column(TypeName = "numeric")]
        public int IdPerson { get; set; }

        public virtual StructurePart StructurePart { get; set; }

        public virtual Person Person { get; set; }
    }
}
