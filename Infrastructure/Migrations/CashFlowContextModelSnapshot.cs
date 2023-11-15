﻿// <auto-generated />
using System;
using CashFlowAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CashFlowAPI.Infrastructure.Migrations
{
    [DbContext(typeof(CashFlowContext))]
    partial class CashFlowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.FinancialEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Caregory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SheetId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SheetId");

                    b.ToTable("FinancialEntries", (string)null);
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.FinancialExpense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Caregory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ExpenseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SheetId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SheetId");

                    b.ToTable("FinancialExpenses", (string)null);
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.Sheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sheets", (string)null);
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.FinancialEntry", b =>
                {
                    b.HasOne("CashFlowAPI.Domain.Entities.Sheet", "Sheet")
                        .WithMany("FinancialEntries")
                        .HasForeignKey("SheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sheet");
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.FinancialExpense", b =>
                {
                    b.HasOne("CashFlowAPI.Domain.Entities.Sheet", "Sheet")
                        .WithMany("FinancialExpenses")
                        .HasForeignKey("SheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sheet");
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.Sheet", b =>
                {
                    b.HasOne("CashFlowAPI.Domain.Entities.User", null)
                        .WithMany("Sheets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.User", b =>
                {
                    b.OwnsOne("CashFlowAPI.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .HasColumnType("TEXT")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("CashFlowAPI.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Password");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.Sheet", b =>
                {
                    b.Navigation("FinancialEntries");

                    b.Navigation("FinancialExpenses");
                });

            modelBuilder.Entity("CashFlowAPI.Domain.Entities.User", b =>
                {
                    b.Navigation("Sheets");
                });
#pragma warning restore 612, 618
        }
    }
}
