using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dev_2_Dev.Models
{
    public class Mentor
    {
        public Mentor()
        {
            
        }

        [Key]
        public int MentorId { get; set; }

        //[ForeignKey("Skill")]
        public int MentorSkillId { get; set; }

        //[ForeignKey("User")]
        public int MentorUserId { get; set; }

        [ForeignKey("MentorSkillId")]
        public virtual Skill Skill { get; set; }

        [ForeignKey("MentorUserId")]
        public virtual User User { get; set; }
    }
}