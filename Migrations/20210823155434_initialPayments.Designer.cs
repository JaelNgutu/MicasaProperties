﻿// <auto-generated />
using MicasaProperties.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicasaProperties.Migrations
{
    [DbContext(typeof(MicasaContext))]
    [Migration("20210823155434_initialPayments")]
    partial class initialPayments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicasaProperties.Models.Building", b =>
                {
                    b.Property<int>("BuildingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CostPerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsAvailable")
                        .HasColumnType("int");

                    b.HasKey("BuildingID");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("MicasaProperties.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("TenantID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("MicasaProperties.Models.Tenant", b =>
                {
                    b.Property<int>("TenantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Occupying")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenantID");

                    b.HasIndex("BuildingID");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("MicasaProperties.Models.Payment", b =>
                {
                    b.HasOne("MicasaProperties.Models.Tenant", "Tenant")
                        .WithMany("Payments")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("MicasaProperties.Models.Tenant", b =>
                {
                    b.HasOne("MicasaProperties.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("MicasaProperties.Models.Tenant", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
