using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.NumeroVenda).IsRequired();
                entity.Property(v => v.Cliente).IsRequired();
                entity.Property(v => v.Filial).IsRequired();
            });

            modelBuilder.Entity<ItemVenda>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Produto).IsRequired();
                entity.Property(i => i.Quantidade).IsRequired();
                entity.Property(i => i.PrecoUnitario).IsRequired();
            });
        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=DeveloperStoreDB;User Id=postgres;Password=12345678;"); 
                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
    }
}