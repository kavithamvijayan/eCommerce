using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaSecretAspCore.Models
{
// Model class for Reviews
    public class Reviews
    {
        public int Id { get; set; }
        [ ForeignKey("Gifts")]
        public int giftId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string image { get; set; }
    }
}
