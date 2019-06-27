﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rest_api.models;

namespace restapi.Migrations
{
    [DbContext(typeof(DbCtx))]
    [Migration("20190627162600_rest_api.models.DbCtx")]
    partial class rest_apimodelsDbCtx
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("rest_api.models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("rest_api.models.Contract", b =>
                {
                    b.Property<int>("ContactId");

                    b.Property<int>("EntrepriseId");

                    b.Property<int?>("ContractType");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("TVA");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ContactId", "EntrepriseId");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("rest_api.models.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<int>("EntrepriseId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<bool>("isSiegeCentral");

                    b.HasKey("EntityId");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Entity");
                });

            modelBuilder.Entity("rest_api.models.Entreprise", b =>
                {
                    b.Property<int>("EntrepriseId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Tva")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("EntrepriseId");

                    b.ToTable("Entreprise");
                });

            modelBuilder.Entity("rest_api.models.Contact", b =>
                {
                    b.OwnsOne("rest_api.models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ContactId");

                            b1.Property<string>("City");

                            b1.Property<string>("Street");

                            b1.ToTable("Contact");

                            b1.HasOne("rest_api.models.Contact")
                                .WithOne("Address")
                                .HasForeignKey("rest_api.models.Address", "ContactId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("rest_api.models.Contract", b =>
                {
                    b.HasOne("rest_api.models.Contact", "Contact")
                        .WithMany("Contracts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("rest_api.models.Entreprise", "Entreprise")
                        .WithMany("Contracts")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("rest_api.models.Entity", b =>
                {
                    b.HasOne("rest_api.models.Entreprise", "Entreprise")
                        .WithMany("Entities")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("rest_api.models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EntityId");

                            b1.Property<string>("City");

                            b1.Property<string>("Street");

                            b1.ToTable("Entity");

                            b1.HasOne("rest_api.models.Entity")
                                .WithOne("Address")
                                .HasForeignKey("rest_api.models.Address", "EntityId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
