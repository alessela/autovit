﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webAPI.Context;

#nullable disable

namespace webAPI.Migrations.Model
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.1.22076.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("webAPI.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("webAPI.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK_Model");

                    b.HasIndex("BrandId");

                    b.ToTable("Model", (string)null);
                });

            modelBuilder.Entity("webAPI.Models.Model", b =>
                {
                    b.HasOne("webAPI.Models.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}