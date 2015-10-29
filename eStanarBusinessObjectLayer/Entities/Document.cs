using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("DOCUMENT")]
    public partial class Document
    {
        [Key]
        [Column("ID_DOCUMENT", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDocument { get; set; }

        [Column("ID_STRUCTURE", TypeName = "numeric")]
        public int IdStructure { get; set; }

        [Column("ID_ENTRANCE", TypeName = "numeric")]
        public int? IdEntrance { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FILE_TYPE")]
        public string FileType { get; set; }

        [Required]
        [Column("DATA")]
        public byte[] Data { get; set; }

        [Required]
        [StringLength(250)]
        [Column("TITLE")]
        public string Title { get; set; }

        [StringLength(250)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("ID_AUTHOR", TypeName = "numeric")]
        public int IdAuthor { get; set; }

        [Column("DATE_CREATED")]
        public DateTime DateCreated { get; set; }

        public virtual Structure Structure { get; set; }

        public virtual Entrance Entrance { get; set; }

        public virtual Person Person { get; set; }
    }
}
