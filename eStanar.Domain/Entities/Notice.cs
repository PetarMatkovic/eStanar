using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("NOTICE")]
    public partial class Notice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notice()
        {
            NoticeComment = new HashSet<NoticeComment>();
            Poll = new HashSet<Poll>();
        }

        [Key]
        [Column("ID_NOTICE", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotice { get; set; }

        [Column("ID_NOTICE_TYPE", TypeName = "numeric")]
        public int IdNoticeType { get; set; }

        [Column("ID_STRUCTURE", TypeName = "numeric")]
        public int IdStructure { get; set; }

        [Required]
        [StringLength(1000)]
        [Column("TEXT")]
        public string Text { get; set; }

        [Column("ID_AUTHOR", TypeName = "numeric")]
        public int IdAuthor { get; set; }

        [Column("DATE", TypeName = "date")]
        public DateTime Date { get; set; }

        [Column("ID_ENTRANCE", TypeName = "numeric")]
        public int? IdEntrance { get; set; }

        [Column("ID_MEETING", TypeName = "numeric")]
        public int? IdMeeting { get; set; }

        [NotMapped]
        public string CssClass { get { return (IdNoticeType == (int)NoticeTypeEnum.OpcaObavijest) ? "bg-info" : "bg-warning"; } }

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
