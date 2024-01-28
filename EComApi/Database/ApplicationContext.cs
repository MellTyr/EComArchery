using System;
using EComApi.Database.Models;
using EComApi.Database.Models.Enums;
using EComApi.Database.Models.PossibleAttrTypes;
using Microsoft.EntityFrameworkCore;

namespace EComApi.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<TextAttribute> TextAttributes { get; set; }
        public virtual DbSet<ChoiseAttribute> ChoiseAttributes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChoiseAttribute>().HasMany(x => x.Values)
                .WithOne(x => x.ChoiseAttribute);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.ChoiseValues)
                .WithMany(x=> x.Products);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.TextValues)
                .WithOne(x=>x.Product)
                .HasForeignKey(x=>x.ProductId);

            modelBuilder.Entity<TextAttribute>()
                .HasMany(x => x.TextValues)
                .WithOne(x => x.TextAttribute)
                .HasForeignKey(x => x.TextAttributeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

