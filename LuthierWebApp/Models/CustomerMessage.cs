using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuthierWebApp.Models
{
    public class CustomerMessage
    {
        public int CustomerMessageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerSurname { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(300)]
        public string Message { get; set; }

        public DateTime SentAt { get; set; }

    }
}