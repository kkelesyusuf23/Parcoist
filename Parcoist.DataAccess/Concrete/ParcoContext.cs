using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DataAccess.Concrete
{
    public class ParcoContext : DbContext
    {
        readonly IConfiguration _configuration;

        public ParcoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductVariantValue>()
            .HasOne(pvv => pvv.FeatureValue)
            .WithMany()
            .HasForeignKey(pvv => pvv.FeatureValueID)
            .OnDelete(DeleteBehavior.NoAction); // 🚫 Cascade değil


            modelBuilder.Entity<Adress>()
            .HasOne(a => a.District)
            .WithMany()
            .HasForeignKey(a => a.DistrictID)
            .OnDelete(DeleteBehavior.NoAction); // ✅ Bu satır sorunu çözer


            modelBuilder.Entity<Delivery>()
            .HasOne(d => d.Order) // Delivery ile Order ilişkisi
            .WithOne(o => o.Delivery) // Order ile Delivery'nin bire bir ilişkisi
            .HasForeignKey<Delivery>(d => d.OrderID) // OrderID foreign key
            .OnDelete(DeleteBehavior.NoAction); // Cascade değil

            modelBuilder.Entity<ReturnItem>()
    .HasOne(ri => ri.ReturnRequest)
    .WithOne(rr => rr.ReturnItem)
    .HasForeignKey<ReturnItem>(ri => ri.ReturnRequestID)
    .OnDelete(DeleteBehavior.Restrict); // veya DeleteBehavior.NoAction


        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCoupon> CustomerCoupons { get; set; }
        public DbSet<CustomerFavory> CustomerFavories { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryStatus> DeliveriesStatus { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<FeatureType> FeatureTypes { get; set; }
        public DbSet<FeatureTypeCategory> FeatureTypeCategories { get; set; }
        public DbSet<FeatureValue> FeatureValues { get; set; }
        public DbSet<Logo> Logo { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBrandStatus> OrdersBrandStatus { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariantCombination> ProductVariantCombinations { get; set; }
        public DbSet<ProductVariantValue> ProductVariantValues { get; set; }
        public DbSet<ReturnImage> ReturnImages { get; set; }
        public DbSet<ReturnItem> ReturnItems { get; set; }
        public DbSet<ReturnProcess> ReturnProcesss { get; set; }
        public DbSet<ReturnReason> ReturnReasons { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<ReturnStatus> ReturnStatuses { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<UserComment> UserComments { get; set; }

    }
}
