using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaSecretAspCore.Models
{
// Model class for Cart
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("Gifts")]
        public int giftId { get; set; }
        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public int quantity { get; set; }
    }
}
