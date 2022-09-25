using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Domain.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
