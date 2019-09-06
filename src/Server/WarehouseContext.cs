using Microsoft.EntityFrameworkCore;
using NiceLabel.Demo.Server.Infrastructure;
using NiceLabel.Demo.Server.Models;

namespace NiceLabel.Demo.Server
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed<Customer>(10);
        }
        public DbSet<Customer> Customers { get; set; }
    }
}