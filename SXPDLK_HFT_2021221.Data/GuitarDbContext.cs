﻿using Microsoft.EntityFrameworkCore;
using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Data
{
    public partial class GuitarDbContext:DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Guitar> Guitars { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public GuitarDbContext()
        {
            this.Database.EnsureCreated();
        }
        public GuitarDbContext(DbContextOptions<GuitarDbContext> options):base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database1.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand fender = new Brand() { Id = 1, Name = "Fender" };
            Brand gibson = new Brand() { Id = 2, Name = "Gibson" };
            Brand ibanez = new Brand() { Id = 3, Name = "Ibanez" };

            Guitar fender1 = new Guitar() { Id = 1, BrandId = fender.Id, Price = 50000, Model = "Fender Bullet Stratocaster" };
            Guitar fender2 = new Guitar() { Id = 2, BrandId = fender.Id, Price = 70000, Model = "Fender Mustang Stratocaster" };
            Guitar gibson1 = new Guitar() { Id = 3, BrandId = gibson.Id, Price = 200000, Model = "Gibson Les Paul" };
            Guitar ibanez1 = new Guitar() { Id = 4, BrandId = ibanez.Id, Price = 60000, Model = "Ibanez GRG121DX" };

            Purchase purchase1 = new Purchase() { Id = 1, BuyerName = "Django Reinhardt", GuitarId = fender1.Id };
            Purchase purchase2 = new Purchase() { Id = 2, BuyerName = "Slash", GuitarId = gibson1.Id };

            modelBuilder.Entity<Guitar>(entity =>
            {
                entity.HasOne(guitar => guitar.Brand)
                    .WithMany(brand => brand.Guitars)
                    .HasForeignKey(guitar => guitar.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Brand>().HasData(fender, ibanez, gibson);
            modelBuilder.Entity<Guitar>().HasData(fender1,fender2 ,ibanez1, gibson1);
            modelBuilder.Entity<Purchase>().HasData(purchase1, purchase2);
        }
    }
}
