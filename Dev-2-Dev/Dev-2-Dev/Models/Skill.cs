using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dev_2_Dev.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Column("Skill")]
        public string Skill1 { get; set; }

    }
}