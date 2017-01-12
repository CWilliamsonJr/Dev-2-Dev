using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
// ReSharper disable VirtualMemberCallInConstructor

namespace Dev_2_Dev.Models
{
    [Table("Mentors")]
    public class Mentor
    {
        public Mentor()
        {
            MentorSkill = new HashSet<MentorSkill>();
            Tutor = new HashSet<Tutor>();
        }

        [Key]
        public int MentorId { get; set; }

        public int MentorUserId { get; set; }

        [ForeignKey("MentorUserId")]
        public virtual User User { get; set; }

        public virtual ICollection<MentorSkill> MentorSkill { get; set; }
        public virtual ICollection<Tutor> Tutor { get; set; }
    }
}