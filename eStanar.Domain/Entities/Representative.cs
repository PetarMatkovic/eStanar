using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("Representative")]
    public partial class Representative
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRepresentative { get; set; }

        [Column(TypeName = "numeric")]
        public int IdStructure { get; set; }

        [Column(TypeName = "numeric")]
        public int IdPerson { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public virtual Person Person { get; set; }

        public virtual Structure Structure { get; set; }
    }
}
