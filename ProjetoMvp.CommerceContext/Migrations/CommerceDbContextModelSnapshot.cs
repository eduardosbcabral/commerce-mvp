﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetoMvp.CommerceContext.Infra;

namespace ProjetoMvp.CommerceContext.Migrations
{
    [DbContext(typeof(CommerceDbContext))]
    partial class CommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ProjetoMvp.CommerceContext.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("TB_ACCOUNT");
                });

            modelBuilder.Entity("ProjetoMvp.CommerceContext.Domain.Entities.Commerce", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SiteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TB_COMMERCE");
                });

            modelBuilder.Entity("ProjetoMvp.CommerceContext.Domain.Entities.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("CommerceId")
                        .HasColumnType("uuid");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CommerceId")
                        .IsUnique();

                    b.ToTable("TB_SITE");
                });

            modelBuilder.Entity("ProjetoMvp.CommerceContext.Domain.Entities.Account", b =>
                {
                    b.OwnsOne("ProjetoMvp.CommerceContext.Domain.ValueObjects.Age", "Age", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Value")
                                .HasColumnType("integer")
                                .HasColumnName("Age");

                            b1.HasKey("AccountId");

                            b1.ToTable("TB_ACCOUNT");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.OwnsOne("ProjetoMvp.CommerceContext.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.HasKey("AccountId");

                            b1.ToTable("TB_ACCOUNT");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.OwnsOne("ProjetoMvp.CommerceContext.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Password");

                            b1.HasKey("AccountId");

                            b1.ToTable("TB_ACCOUNT");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.Navigation("Age")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoMvp.CommerceContext.Domain.Entities.Commerce", b =>
                {
                    b.OwnsOne("ProjetoMvp.CommerceContext.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CommerceId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Country");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.Property<int>("TempId1")
                                .HasColumnType("integer");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("text")
                                .HasColumnName("ZipCode");

                            b1.HasKey("CommerceId");

                            b1.ToTable("TB_ADDRESS");

                            b1.WithOwner()
                                .HasForeignKey("CommerceId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ProjetoMvp.CommerceContext.Domain.Entities.Site", b =>
                {
                    b.HasOne("ProjetoMvp.CommerceContext.Domain.Entities.Commerce", "Commerce")
                        .WithOne("Site")
                        .HasForeignKey("ProjetoMvp.CommerceContext.Domain.Entities.Site", "CommerceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Commerce");
                });

            modelBuilder.Entity("ProjetoMvp.CommerceContext.Domain.Entities.Commerce", b =>
                {
                    b.Navigation("Site");
                });
#pragma warning restore 612, 618
        }
    }
}
