using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.Shared.Domain.Entities;

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
                .Property(x => x.Name);

            modelBuilder.Entity<Commerce>()
                .Property(x => x.Active);

            modelBuilder.Entity<Commerce>()
                .OwnsOne(x => x.Address)
                .Property(x => x.Street)
                .HasColumnName("Street");

            modelBuilder.Entity<Commerce>()
                .OwnsOne(x => x.Address)
                .Property(x => x.City)
                .HasColumnName("City")
                .IsRequired();

            modelBuilder.Entity<Commerce>()
                .OwnsOne(x => x.Address)
                .Property(x => x.State)
                .HasColumnName("State")
                .IsRequired();

            modelBuilder.Entity<Commerce>()
                .OwnsOne(x => x.Address)
                .Property(x => x.ZipCode)
                .HasColumnName("ZipCode");

            modelBuilder.Entity<Commerce>()
                .OwnsOne(x => x.Address)
                .Property(x => x.Country)
                .HasColumnName("Country")
                .IsRequired();
        }
    }
}
