using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuthierWebApp.Models
{
    public class Luthier
    {
        public int LuthierId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialization { get; set; }
        public DateTime EmployedAt { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}