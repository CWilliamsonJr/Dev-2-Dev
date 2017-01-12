using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dev_2_Dev.Models
{
    public class MentorSkill
    {
        public MentorSkill()
        {
            
        }

        [Key]
        public int MentorId { get; set; }
        
        public int MentorSkillId { get; set; }
        public int MentorUserId { get; set; }

        [ForeignKey("MentorSkillId")]
        public virtual Skill Skill { get; set; }

        [ForeignKey("MentorUserId")]
        public virtual Mentor Mentor { get; set; }
    }
}