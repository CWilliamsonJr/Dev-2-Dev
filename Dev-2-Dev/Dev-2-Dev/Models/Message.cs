using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dev_2_Dev.Models
{
    public class Message
    {
        public Message()
        {
            
        }

        [Key]
        public int MessageId { get; set; }

        public int ToUserId { get; set; }
        public int? FromUserId { get; set; }

        [Required]
        [Column("Message")]
        [StringLength(256)]
        public string Message1 { get; set; }

        [ForeignKey("ToUserId")]
        public virtual User ToUser { get; set; }

        [ForeignKey("FromUserId")]
        public virtual User FromUser { get; set; }
    }
}