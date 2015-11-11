using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("Document")]
    public partial class Document
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDocument { get; set; }

        [Column(TypeName = "numeric")]
        public int IdStructure { get; set; }

        [Column(TypeName = "numeric")]
        public int? IdEntrance { get; set; }

        [Required]
        [StringLength(50)]
        public string FileType { get; set; }

        [Required]
        public byte[] Data { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "numeric")]
        public int IdAuthor { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Structure Structure { get; set; }

        public virtual Entrance Entrance { get; set; }

        public virtual Person Person { get; set; }
    }
}
