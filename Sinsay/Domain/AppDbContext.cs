using Microsoft.EntityFrameworkCore;
using Sinsay.Domain.Predefined;
using Sinsay.Models;

namespace Sinsay.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<City> Citys { get; set; } 
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }    
        public DbSet<PaymentMethod> PaymentMethods { get; set; }    
        public DbSet<PickupPoint> PickupPoints { get; set;}
        public DbSet<ShoppingCart> ShoppingCarts { get; set;}

        //public AppDbContext()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring (DbContextOptionsBuilder opts)
        {
            opts.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sinsaydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //.\SQLEXPRESS;
            //opts.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\sinsaydb.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new PD_Roles().roles);
            modelBuilder.Entity<AppUser>().HasData(new PD_Users().users);
            modelBuilder.Entity<City>().HasData(new PD_Cities().cities);
            modelBuilder.Entity<PaymentMethod>().HasData(new PD_PaymentMethods().paymentMethods);
            modelBuilder.Entity<PickupPoint>().HasData(new PD_PickupPoints().pickupPoints);
            modelBuilder.Entity<Clothes>().HasData(new PD_Clothes().clothes);
            modelBuilder.Entity<OrderStatus>().HasData(new PD_OrderStatuses().orders);
        }
    }
}
