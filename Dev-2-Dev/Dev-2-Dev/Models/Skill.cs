using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
// ReSharper disable VirtualMemberCallInConstructor

namespace Dev_2_Dev.Models
{
    public class Skill
    {
        public Skill()
        {
            MentorSkills = new HashSet<Mentor>();
            MenteeSkills = new HashSet<Mentee>();
        }

        [Key]
        public int SkillId { get; set; }

        [Column("Skill")]
        public string Skill1 { get; set; }

        public virtual ICollection<Mentor> MentorSkills { get; set; }
        public virtual ICollection<Mentee> MenteeSkills { get; set; }
    }
}