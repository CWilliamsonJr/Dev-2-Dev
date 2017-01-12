using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
// ReSharper disable VirtualMemberCallInConstructor

namespace Dev_2_Dev.Models
{
    [Table("Mentee")]
    public class Mentee
    {
        public Mentee()
        {
            MenteeSkill = new HashSet<MenteeSkill>();
        }

        [Key]
        public int MenteeId { get; set; }
        public int MenteeUserId { get; set; }

        [ForeignKey("MenteeUserId")]
        public virtual User User { get; set; }

        
        public virtual ICollection<MenteeSkill> MenteeSkill { get; set; }
    }
}