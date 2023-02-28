﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoteInRestaurant.Model.Context;

#nullable disable

namespace VoteInRestaurant.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VoteInRestaurant.Model.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("VoteInRestaurant.Model.Restaurante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("restaurant");
                });

            modelBuilder.Entity("VoteInRestaurant.Model.Voto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint");

                    b.Property<long>("RestauranteID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("RestauranteID");

                    b.ToTable("Votos");
                });

            modelBuilder.Entity("VoteInRestaurant.Model.Voto", b =>
                {
                    b.HasOne("VoteInRestaurant.Model.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteInRestaurant.Model.Restaurante", "Restaurante")
                        .WithMany()
                        .HasForeignKey("RestauranteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Restaurante");
                });
#pragma warning restore 612, 618
        }
    }
}
