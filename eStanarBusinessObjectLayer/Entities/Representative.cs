using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("REPRESENTATIVE")]
    public partial class Representative
    {
        [Key]
        [Column("ID_REPRESENTATIVE", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRepresentative { get; set; }

        [Column("ID_STRUCTURE", TypeName = "numeric")]
        public int IdStructure { get; set; }

        [Column("ID_PERSON", TypeName = "numeric")]
        public int IdPerson { get; set; }

        [Column("DATE_FROM", TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column("DATE_TO", TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public virtual Person Person { get; set; }

        public virtual Structure Structure { get; set; }
    }
}
