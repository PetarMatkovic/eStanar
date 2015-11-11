using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("PollVote")]
    public partial class PollVote
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPollVote { get; set; }

        [Column(TypeName = "numeric")]
        public int IdPollOption { get; set; }

        [Column(TypeName = "numeric")]
        public int IdPerson { get; set; }

        public DateTime Date { get; set; }

        public virtual Person Person { get; set; }

        public virtual PollOption PollOption { get; set; }
    }
}
