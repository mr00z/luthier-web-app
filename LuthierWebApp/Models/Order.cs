using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuthierWebApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int LuthierId { get; set; }
        public Luthier Luthier { get; set; }

        public int GuitarId { get; set; }
        public Guitar Guitar { get; set; }
    }
}