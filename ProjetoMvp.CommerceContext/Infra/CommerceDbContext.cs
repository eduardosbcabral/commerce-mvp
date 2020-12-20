using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ProjetoMvp.CommerceContext.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Infra
{
    public class CommerceDbContext : DbContext
    {
        public DbSet<Commerce> Commerces { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductImage> ProductImages { get; set; }
        //public DbSet<Site> Sites { get; set; }

        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Commerce>()
                .ToTable("TB_COMMERCE")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Commerce>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Commerce>()
                .Property(x => x.Active)
                .IsRequired();

            modelBuilder.Entity<Commerce>()
                .OwnsOne(x => x.Address, a =>
                {
                    a.Property(x => x.Street)
                        .HasColumnName("Street");
                    a.Property(x => x.City)
                        .HasColumnName("City")
                        .IsRequired();
                    a.Property(x => x.State)
                        .HasColumnName("State")
                        .IsRequired();
                    a.Property(x => x.ZipCode)
                        .HasColumnName("ZipCode");
                    a.Property(x => x.Country)
                        .HasColumnName("Country")
                        .IsRequired();
                });

            modelBuilder.Entity<Site>()
                .ToTable("TB_SITE")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Site>()
                .Property(x => x.Domain)
                .IsRequired();

            modelBuilder.Entity<Site>()
                .Property(x => x.Active)
                .IsRequired();
        }
    }
}
