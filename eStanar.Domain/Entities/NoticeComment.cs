using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("NoticeComment")]
    public partial class NoticeComment
    {
        [Key]
        [Column("ID_NOTICE_COMMENT", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNoticeComment { get; set; }

        [Column(TypeName = "numeric")]
        public int IdNotice { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }

        [Column(TypeName = "numeric")]
        public int IdAuthor { get; set; }

        public DateTime Date { get; set; }

        public virtual Notice Notice { get; set; }

        public virtual Person Person { get; set; }
    }
}
