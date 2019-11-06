using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public partial class MarketPlaceDbContext : IdentityDbContext<ApplicationUser>
    {
        public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //                optionsBuilder.UseSqlServer("Server=35.183.157.143,1433\\\\\\\\DEV;Database=TestAjay;User ID=NBPOwner_01;Password=4gO7R#2E;MultipleActiveResultSets=true");
            }
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Path).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Checked).HasColumnType("bit");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnType("int");
                entity.Property(e => e.UserId).HasMaxLength(255);
            });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "FavaSofa-Grey",
                    Description = "The Fava sofa offers up a perfect look and feel when you need a place to unwind.Made in Canada.",
                    Path = "/images/FavaSofa-Grey.jpg",
                    Price = Convert.ToDecimal(1000.09),
                    Checked = false

                },
                new Product
                {
                    Id = 2,
                    Name = "NaplesSofa-WarmBeige",
                    Description = "You will love talking and laughing with family and friends when you sit in the stylish, supple Naples sofa in warm beige.",
                    Path = "/images/NaplesSofa-WarmBeige.jpg",
                    Price = 2005,
                    Checked = false
                },
                new Product
                {
                    Id = 3,
                    Name = "XoomConvertibleSofa-Black",
                    Description = "The versatile Xoom convertible sofa helps you make the most of your space. It is perfect in an office, teens room, living room or anyplace you could use a sofa that doubles as a spot for overnight guests.",
                    Path = "/images/XoomConvertibleSofa-Black.jpg",
                    Price = Convert.ToDecimal(3000.59),
                    Checked = false
                }
                );

            //OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
