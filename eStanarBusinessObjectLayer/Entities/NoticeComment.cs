using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("NOTICE_COMMENT")]
    public partial class NoticeComment
    {
        [Key]
        [Column("ID_NOTICE_COMMENT", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNoticeComment { get; set; }

        [Column("ID_NOTICE", TypeName = "numeric")]
        public int IdNotice { get; set; }

        [Required]
        [StringLength(1000)]
        [Column("TEXT")]
        public string Text { get; set; }

        [Column("ID_AUTHOR", TypeName = "numeric")]
        public int IdAuthor { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        public virtual Notice Notice { get; set; }

        public virtual Person Person { get; set; }
    }
}
