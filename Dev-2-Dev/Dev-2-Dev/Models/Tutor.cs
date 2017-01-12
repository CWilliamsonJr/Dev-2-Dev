using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dev_2_Dev.Models
{
    public class Tutor
    {
        [Key]
        public int TutorId { get; set; }

        [Index("IX_MentorMentee", 1, IsUnique = true)]
        public int? MentorId { get; set; }

        [Index("IX_MentorMentee", 2, IsUnique = true)]
        public int? MenteeId { get; set; }

        [ForeignKey("MentorId")]
        public virtual Mentor Mentor { get; set; }

        [ForeignKey("MenteeId")]
        public virtual Mentee Mentee { get; set; }
    }
}