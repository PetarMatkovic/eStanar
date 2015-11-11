using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("Notice")]
    public partial class Notice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notice()
        {
            NoticeComment = new HashSet<NoticeComment>();
            Poll = new HashSet<Poll>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotice { get; set; }

        [Column(TypeName = "numeric")]
        public int IdNoticeType { get; set; }

        [Column(TypeName = "numeric")]
        public int IdStructure { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }

        [Column(TypeName = "numeric")]
        public int IdAuthor { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "numeric")]
        public int? IdEntrance { get; set; }

        [Column(TypeName = "numeric")]
        public int? IdMeeting { get; set; }

        public virtual Entrance Entrance { get; set; }

        public virtual Meeting Meeting { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoticeComment> NoticeComment { get; set; }

        public virtual NoticeType NoticeType { get; set; }

        public virtual Structure Structure { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poll> Poll { get; set; }
    }
}
