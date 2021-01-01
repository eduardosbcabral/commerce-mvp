using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMvp.CommerceContext.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Infra.Maps
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("TB_ACCOUNT")
                .HasKey(x => x.Id);

            builder.OwnsOne(x => x.Age)
                .Property(x => x.Value)
                .HasColumnName("Age")
                .IsRequired();

            builder.Navigation(e => e.Age).IsRequired();

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .HasColumnName("Email")
                .IsRequired();

            builder.Navigation(e => e.Email)
                .IsRequired();

            builder.OwnsOne(x => x.Password)
                .Property(x => x.Value)
                .HasColumnName("Password")
                .IsRequired();

            builder.Navigation(e => e.Password)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
