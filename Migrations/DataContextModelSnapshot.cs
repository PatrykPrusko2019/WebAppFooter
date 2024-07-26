﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppFooter.Data;

#nullable disable

namespace WebAppFooter.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

            modelBuilder.Entity("WebAppFooter.Entities.Footer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartmentChange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailChange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoChange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameSurnameChange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneChange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SiteChange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });
#pragma warning restore 612, 618
        }
    }
}
