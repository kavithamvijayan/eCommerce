﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SantaSecretAspCore.Models;

namespace SantaSecretAspCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SantaSecretAspCore.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerId");

                    b.Property<int>("giftId");

                    b.Property<int>("quantity");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("SantaSecretAspCore.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address");

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.Property<string>("password");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SantaSecretAspCore.Models.Gifts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("desc");

                    b.Property<string>("image");

                    b.Property<string>("name");

                    b.Property<double>("price");

                    b.Property<double>("shippingCost");

                    b.HasKey("Id");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("SantaSecretAspCore.Models.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<string>("body");

                    b.Property<int>("giftId");

                    b.Property<string>("image");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}