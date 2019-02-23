using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LuthierWebApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Message")]
        public string Value { get; set; }
        public DateTime SentAt { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}