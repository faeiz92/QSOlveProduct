using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public RepositoryContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //connect to sql server with connection string from app settings
            options.UseSqlite("Data Source=C:\\Users\\faeiz\\OneDrive\\Desktop\\databasesqlite\\qsolveproductdb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductCategory)
            .WithMany(pc => pc.Products)
            .HasForeignKey(p => p.ProductCategoryId);*/

            /*modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);*/

            /*modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);*/
            /*modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(od => od.Orders)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(od => od.ProductId);*/

            /*modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductCategories)
            .WithMany(pc => pc.Products)
            .HasForeignKey(p => p.ProductCategoryId);*/

            modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductCategories)
            .WithMany(pc => pc.Products)
            .HasForeignKey(p => p.ProductCategoryId);

            modelBuilder.Entity<OrderItem>()
           .HasOne(oi => oi.Orders)
           .WithMany(o => o.OrderItems)
           .HasForeignKey(oi => oi.OrderId);

            // Define relationship between OrderItems and Products
           /* modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Products)
                .WithOne(p => p.or)
                .HasForeignKey(oi => oi.ProductId);*/

            // Define relationship between Products and ProductCategories
            

            // Optional: Configure cascade delete behavior if desired
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Orders)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orders>()
                .HasMany(oi => oi.OrderItems)
                .WithOne(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orders>()
            .HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);



        }
    }
}
