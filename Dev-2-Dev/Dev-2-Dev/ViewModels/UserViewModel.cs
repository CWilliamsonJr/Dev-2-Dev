using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dev_2_Dev.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Must Enter a First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must Enter a Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Twitter { get; set; }

        [StringLength(50)]
        public string Linkedin { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Please enter something about yourself")]
        public string AboutMe { get; set; }
    }
}