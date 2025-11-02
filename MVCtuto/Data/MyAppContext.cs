using Microsoft.EntityFrameworkCore;
using MVCtuto.Models;

namespace MVCtuto.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 4, Name = "Item 1", Price = 10.00, SerialNumberId = 10 }
            );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "Serial Number 1" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" }
            );

            modelBuilder.Entity<ItemClient>().HasKey(ic => new { ic.ItemId, ic.ClientId });
            modelBuilder.Entity<ItemClient>().HasOne(ic => ic.Item).WithMany(i => i.ItemClients).HasForeignKey(ic => ic.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(ic => ic.Client).WithMany(c => c.ItemClients).HasForeignKey(ic => ic.ClientId);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}