using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SantaSecretAspCore.Models
{
// Model class for AppDbContxt
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Gifts> Gifts { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
    }
}
