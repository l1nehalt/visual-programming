using lab_12.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab_12.Data
{
    public class SupplyContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\Projects\Visual-Programming\lab-12\Data\supply.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supply>()
            .HasKey(s => new { s.SupplierId, s.ItemId, s.Date });

            modelBuilder.Entity<Item>()
                .HasData(
                new Item { Id = 1, Name = "Ложка", Manufacturer = "Леруа Мерлен", Price = 10.0000m },
                new Item { Id = 2, Name = "Вилка", Manufacturer = "Вилочный завод", Price = 50.0000m },
                new Item { Id = 3, Name = "Нож", Manufacturer = "Ножи от Семёна", Price = 30.0000m },
                new Item { Id = 4, Name = "Тарелка", Manufacturer = "Мир керамики", Price = 50.0000m },
                new Item { Id = 5, Name = "Кружка", Manufacturer = "Апельсин", Price = 100.0000m }
            );

            modelBuilder.Entity<Supplier>()
                .HasData(
                new Supplier { Id = 1, Name = "Иванов", Address = "Рязань", Phone = "465825" },
                new Supplier { Id = 2, Name = "Петров", Address = "Рязань", Phone = "592625" },
                new Supplier { Id = 3, Name = "Сидоров", Address = "Рязань", Phone = "482625" },
                new Supplier { Id = 4, Name = "Кузнецов", Address = "Рязань", Phone = "201736" }
            );

            modelBuilder.Entity<Supply>()
                .HasData(
                new Supply { SupplierId = 1, ItemId = 1, Date = new DateTime(2020, 09, 10), Volume = 100 },
                new Supply { SupplierId = 1, ItemId = 2, Date = new DateTime(2020, 10, 12), Volume = 200 },
                new Supply { SupplierId = 1, ItemId = 3, Date = new DateTime(2020, 11, 14), Volume = 300 },
                new Supply { SupplierId = 1, ItemId = 4, Date = new DateTime(2020, 09, 11), Volume = 500 },
                new Supply { SupplierId = 2, ItemId = 1, Date = new DateTime(2020, 09, 20), Volume = 150 },
                new Supply { SupplierId = 2, ItemId = 2, Date = new DateTime(2020, 09, 21), Volume = 250 },
                new Supply { SupplierId = 2, ItemId = 3, Date = new DateTime(2020, 01, 01), Volume = 100 },
                new Supply { SupplierId = 3, ItemId = 1, Date = new DateTime(2020, 12, 30), Volume = 1000 }
            );
        }
    }

}
