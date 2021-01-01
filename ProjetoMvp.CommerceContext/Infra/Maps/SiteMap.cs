using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMvp.CommerceContext.Domain.Entities;
using System;

namespace ProjetoMvp.CommerceContext.Infra.Maps
{
    public class SiteMap : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("TB_SITE")
                .HasKey(x => x.Id);

            builder.Property(x => x.Domain)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
