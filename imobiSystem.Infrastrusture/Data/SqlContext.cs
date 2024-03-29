using imobiSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Infrastrusture.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
            
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Date") != null))
            {
                if(item.State == EntityState.Added)
                    item.Property("Date").CurrentValue = DateTime.Now;

                if (item.State == EntityState.Modified)
                    item.Property("Date").IsModified = false;
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proprietario>()
                .HasMany(e => e.Corretores)
                .WithMany(e => e.Proprietarios)
                .UsingEntity(
            "ProprietarioCorretor",
            l => l.HasOne(typeof(Corretor)).WithMany().HasForeignKey("CorretoresId").HasPrincipalKey(nameof(Corretor.Id)),
            r => r.HasOne(typeof(Proprietario)).WithMany().HasForeignKey("ProprietariosId").HasPrincipalKey(nameof(Proprietario.Id)),
            j => j.HasKey("ProprietariosId", "CorretoresId"));

            modelBuilder.Entity<Inquilino>()
                .HasMany(e => e.Corretores)
                .WithMany(e => e.Inquilinos)
                .UsingEntity(
            "InquilinoCorretor",
            l => l.HasOne(typeof(Corretor)).WithMany().HasForeignKey("CorretoresId").HasPrincipalKey(nameof(Corretor.Id)),
            r => r.HasOne(typeof(Inquilino)).WithMany().HasForeignKey("InquilinosId").HasPrincipalKey(nameof(Inquilino.Id)),
            j => j.HasKey("InquilinosId", "CorretoresId"));

            modelBuilder.Entity<Proprietario>()
            .HasMany(e => e.Imoveis)
            .WithOne(e => e.Proprietario)
            .HasForeignKey(e => e.ProprietarioId)
            .IsRequired();

            modelBuilder.Entity<Inquilino>()
            .HasMany(e => e.Imoveis)
            .WithOne(e => e.Inquilino)
            .HasForeignKey(e => e.InquilinoId)
            .IsRequired();
        }
    }
}
