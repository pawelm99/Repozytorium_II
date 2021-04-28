﻿// <auto-generated />
using System;
using ConsoleApp19;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp19.Migrations
{
    [DbContext(typeof(TPTKontekst))]
    [Migration("20210428180810_added_abstract")]
    partial class added_abstract
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp19.Osoba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Osoba");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Osoba");
                });

            modelBuilder.Entity("ConsoleApp19.Klient", b =>
                {
                    b.HasBaseType("ConsoleApp19.Osoba");

                    b.Property<string>("NrRejestracyjny")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrTelefonu")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Klient");
                });

            modelBuilder.Entity("ConsoleApp19.Pracownik", b =>
                {
                    b.HasBaseType("ConsoleApp19.Osoba");

                    b.Property<DateTime>("DataZatrudnienia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZwolnienia")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Pracownik");
                });
#pragma warning restore 612, 618
        }
    }
}