using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMvp.CommerceContext.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Infra.Maps
{
    public class CommerceMap : IEntityTypeConfiguration<Commerce>
    {
        public void Configure(EntityTypeBuilder<Commerce> builder)
        {
            builder.ToTable("TB_COMMERCE")
                .HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();

            builder.OwnsOne(x => x.Address, a =>
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

                    a.ToTable("TB_ADDRESS");
                });

            builder.HasOne(x => x.Site)
                .WithOne(x => x.Commerce)
                .HasForeignKey<Site>("CommerceId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
