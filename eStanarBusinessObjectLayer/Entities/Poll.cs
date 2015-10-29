using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("POLL")]
    public partial class Poll
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poll()
        {
            PollOption = new HashSet<PollOption>();
        }

        [Key]
        [Column("ID_POLL", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPoll { get; set; }

        [Column("ID_NOTICE", TypeName = "numeric")]
        public int IdNotice { get; set; }

        [Required]
        [StringLength(250)]
        [Column("TITLE")]
        public string Title { get; set; }

        [Column("DATE_FROM")]
        public DateTime DateFrom { get; set; }

        [Column("DATE_TO")]
        public DateTime? DateTo { get; set; }

        public virtual Notice Notice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PollOption> PollOption { get; set; }
    }
}
