using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("POLL_VOTE")]
    public partial class PollVote
    {
        [Key]
        [Column("ID_POLL_VOTE", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPollVote { get; set; }

        [Column("ID_POLL_OPTION", TypeName = "numeric")]
        public int IdPollOption { get; set; }

        [Column("ID_PERSON", TypeName = "numeric")]
        public int IdPerson { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        public virtual Person Person { get; set; }

        public virtual PollOption PollOption { get; set; }
    }
}
