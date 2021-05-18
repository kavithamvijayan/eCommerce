using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantaSecretAspCore.Models
{
// Model class for Gifts
    public class Gifts
    {
        public int Id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string image { get; set; }
        public string desc { get; set; }
        public double shippingCost { get; set; }
    }
}
