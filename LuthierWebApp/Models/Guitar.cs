using System;
using System.ComponentModel.DataAnnotations;

namespace LuthierWebApp.Models
{
    public class Guitar
    {
        public int GuitarId { get; set; }

        [Required]
        [MaxLength(40)]
        public string Type { get; set; }

        [Required]
        [Display(Name ="Number of strings")]
        public int NrOfStrings { get; set; }

        [Required]
        public int Price { get; set; }

        [Display(Name ="Date of creation")]
        public DateTime CreatedAt { get; set; }
    }
}