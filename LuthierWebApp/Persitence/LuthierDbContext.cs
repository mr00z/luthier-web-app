using LuthierWebApp.Models;
using System.Data.Entity;

namespace LuthierWebApp.Persitence
{
    public class LuthierDbContext : DbContext
    {
        public DbSet<Guitar> Guitars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Luthier> Luthiers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}