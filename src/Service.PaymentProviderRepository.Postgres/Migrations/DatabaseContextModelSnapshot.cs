﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Service.PaymentProviderRepository.Postgres;

#nullable disable

namespace Service.PaymentProviderRepository.Postgres.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("education")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Service.PaymentProviderRepository.Postgres.Models.PaymentProviderEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Currencies")
                        .HasColumnType("text");

                    b.Property<bool?>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<bool?>("KycNeeded")
                        .HasColumnType("boolean");

                    b.Property<string>("RestrictedCountries")
                        .HasColumnType("text");

                    b.Property<string>("SupportCountries")
                        .HasColumnType("text");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.ToTable("payment_provider", "education");
                });
#pragma warning restore 612, 618
        }
    }
}
