using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("POLL_OPTION")]
    public partial class PollOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PollOption()
        {
            PollVote = new HashSet<PollVote>();
        }

        [Key]
        [Column("ID_POLL_OPTION", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPollOption { get; set; }

        [Column("ID_POLL", TypeName = "numeric")]
        public int IdPoll { get; set; }

        [Required]
        [StringLength(50)]
        [Column("TEXT")]
        public string Text { get; set; }

        public virtual Poll Poll { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PollVote> PollVote { get; set; }
    }
}
