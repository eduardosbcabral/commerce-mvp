using Microsoft.EntityFrameworkCore;
using ProjetoMvp.Api.Models;

namespace ProjetoMvp.Api.Infra
{
    public class CommerceMvpContext : DbContext
    {
        public DbSet<Commerce> Commerces { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Site> Sites { get; set; }

        public CommerceMvpContext(DbContextOptions<CommerceMvpContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commerce>()
                .ToTable("TB_COMMERCE")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Commerce>()
                .HasOne(x => x.Site)
                .WithOne(x => x.Commerce)
                .HasForeignKey<Site>(b => b.Id);

            modelBuilder.Entity<Commerce>()
                .HasOne(x => x.Address);

            modelBuilder.Entity<Product>()
                .ToTable("TB_PRODUCT")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Images);

            modelBuilder.Entity<ProductImage>()
                .ToTable("TB_PRODUCT_IMAGE")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Site>()
                .ToTable("TB_SITE")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Address>()
                .ToTable("TB_ADDRESS")
                .HasKey(x => x.Id);
        }
    }
}
