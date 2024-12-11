﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo.Models;

#nullable disable

namespace ToDo.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20241210205046_NullableCategory")]
    partial class NullableCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ToDo.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ToDo.Models.ToDoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Todo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("ToDo.Models.Category", b =>
                {
                    b.HasOne("ToDo.Models.Category", "ParentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ToDo.Models.ToDoItem", b =>
                {
                    b.HasOne("ToDo.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.OwnsOne("ToDo.Models.LocationItem", "Location", b1 =>
                        {
                            b1.Property<long>("ToDoItemId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Latitude")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Longitude")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ToDoItemId");

                            b1.ToTable("ToDoItems");

                            b1.WithOwner()
                                .HasForeignKey("ToDoItemId");
                        });

                    b.Navigation("Category");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ToDo.Models.Category", b =>
                {
                    b.Navigation("Subcategories");
                });
#pragma warning restore 612, 618
        }
    }
}
