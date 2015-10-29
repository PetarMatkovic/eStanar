using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("ACCOUNT")]
    public partial class Account
    {
        [Key]
        [Column("ID_ACCOUNT", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccount { get; set; }

        [Column("ID_PERSON", TypeName = "numeric")]
        public int IdPerson { get; set; }

        [Required]
        [StringLength(50)]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Column("PASSWORD")]
        public string Password { get; set; }

        public virtual Person Person { get; set; }
    }
}
