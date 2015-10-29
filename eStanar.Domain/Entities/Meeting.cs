using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStanar.Domain.Entities
{
    [Table("MEETING")]
    public partial class Meeting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meeting()
        {
            Notice = new HashSet<Notice>();
        }

        [Key]
        [Column("ID_MEETING", TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMeeting { get; set; }

        [Column("ID_MEETING_TYPE", TypeName = "numeric")]
        public int IdMeetingType { get; set; }

        [Column("DATE_CREATED")]
        public DateTime DateCreated { get; set; }

        [Column("DATE_OF_MEETING")]
        public DateTime DateOfMeeting { get; set; }

        [Required]
        [StringLength(50)]
        [Column("TITLE")]
        public string Title { get; set; }

        [StringLength(250)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("PRIORITY", TypeName = "numeric")]
        public int Priority { get; set; }

        public virtual MeetingType MeetingType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notice> Notice { get; set; }
    }
}
