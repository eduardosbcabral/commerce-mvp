using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.CommerceContext.Infra.Maps;
using ProjetoMvp.Shared.Domain.Entities;
using ProjetoMvp.Shared.Domain.ValueObjects;

namespace ProjetoMvp.CommerceContext.Infra
{
    public class CommerceDbContext : DbContext
    {
        public DbSet<Commerce> Commerces { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Site> Sites { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductImage> ProductImages { get; set; }

        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Entity>();
            modelBuilder.Ignore<ValueObject>();
            modelBuilder.Ignore<Age>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Password>();
            modelBuilder.Ignore<Address>();

            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new CommerceMap());
            modelBuilder.ApplyConfiguration(new SiteMap());
        }
    }
}
