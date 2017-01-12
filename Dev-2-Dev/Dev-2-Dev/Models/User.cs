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
            Mentors = new HashSet<Mentor>();
            Mentees = new HashSet<Mentee>();
            ToUserId = new HashSet<Message>();
            FromUserId = new HashSet<Message>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Mentor> Mentors { get; set; }
        public virtual ICollection<Mentee> Mentees { get; set; }

        [InverseProperty("ToUser")]
        public virtual ICollection<Message> ToUserId { get; set; }

        [InverseProperty("FromUser")]
        public virtual ICollection<Message> FromUserId { get; set; }
    }
}