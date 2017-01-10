using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

// ReSharper disable VirtualMemberCallInConstructor
namespace Dev_2_Dev.Models
{
    public class User
    {
        public User()
        {
            MentorSkills = new HashSet<Mentor>();
            MenteeSkills = new HashSet<Mentee>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Mentor> MentorSkills { get; set; }
        public virtual ICollection<Mentee> MenteeSkills { get; set; }

    }
}