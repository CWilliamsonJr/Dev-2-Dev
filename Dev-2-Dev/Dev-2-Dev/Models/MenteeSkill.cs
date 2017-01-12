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
        public int MenteeId { get; set; }

        
        public int MenteeSkillId { get; set; }
        public int MenteeUserId { get; set; }

        [ForeignKey("MenteeSkillId")]
        public virtual Skill Skill { get; set; }

        [ForeignKey("MenteeUserId")]
        public virtual Mentee Mentee { get; set; }
    }
}