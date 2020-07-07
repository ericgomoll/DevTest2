﻿// <auto-generated />
using System;
using EligoCustomerPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EligoCustomerPortal.Data.Migrations
{
    [DbContext(typeof(EligoDataContext))]
    [Migration("20200703213924_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int>("BillingAddressID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("ServiceAddressID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountTypeID");

                    b.HasIndex("AddressID");

                    b.HasIndex("BillingAddressID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ServiceAddressID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            ID = 101,
                            AccountTypeID = 1,
                            BillingAddressID = 2,
                            CustomerID = 1,
                            ServiceAddressID = 2
                        },
                        new
                        {
                            ID = 102,
                            AccountTypeID = 1,
                            BillingAddressID = 1,
                            CustomerID = 2,
                            ServiceAddressID = 1
                        },
                        new
                        {
                            ID = 103,
                            AccountTypeID = 2,
                            BillingAddressID = 1,
                            CustomerID = 2,
                            ServiceAddressID = 3
                        });
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.AccountType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Residential"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Commercial"
                        });
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Chicago",
                            PostalCode = "60606",
                            State = "IL",
                            StreetAddress = "201 West Lake Street"
                        },
                        new
                        {
                            ID = 2,
                            City = "Chicago",
                            PostalCode = "60606",
                            State = "IL",
                            StreetAddress = "333 West Wacker Drive"
                        },
                        new
                        {
                            ID = 3,
                            City = "Chicago",
                            PostalCode = "60606",
                            State = "IL",
                            StreetAddress = "233 South Wacker Drive"
                        });
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EmailAddress = "ericgomoll@gmail.com",
                            FirstName = "Eric",
                            LastName = "Gomoll",
                            PhoneNumber = "(847) 722-9149"
                        },
                        new
                        {
                            ID = 2,
                            EmailAddress = "dsoderna@eligoenergy.com",
                            FirstName = "David",
                            LastName = "Solderna"
                        });
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            ID = 5544,
                            AccountID = 101,
                            Amount = 124.54m,
                            InvoiceDate = new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = true
                        },
                        new
                        {
                            ID = 6062,
                            AccountID = 101,
                            Amount = 117.01m,
                            InvoiceDate = new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = true
                        },
                        new
                        {
                            ID = 6098,
                            AccountID = 101,
                            Amount = 135.04m,
                            InvoiceDate = new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = false
                        },
                        new
                        {
                            ID = 5334,
                            AccountID = 102,
                            Amount = 79.76m,
                            InvoiceDate = new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = true
                        },
                        new
                        {
                            ID = 6097,
                            AccountID = 102,
                            Amount = 114.54m,
                            InvoiceDate = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = true
                        },
                        new
                        {
                            ID = 6114,
                            AccountID = 102,
                            Amount = 122.00m,
                            InvoiceDate = new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = false
                        },
                        new
                        {
                            ID = 5495,
                            AccountID = 103,
                            Amount = 145.43m,
                            InvoiceDate = new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = true
                        },
                        new
                        {
                            ID = 6113,
                            AccountID = 103,
                            Amount = 176.04m,
                            InvoiceDate = new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = true
                        },
                        new
                        {
                            ID = 6122,
                            AccountID = 103,
                            Amount = 191.01m,
                            InvoiceDate = new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsPaid = true
                        });
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("PaymentMethodID");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            ID = 4432,
                            Amount = 124.54m,
                            InvoiceID = 5544,
                            PaymentDate = new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodID = 1
                        },
                        new
                        {
                            ID = 4954,
                            Amount = 117.01m,
                            InvoiceID = 6062,
                            PaymentDate = new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodID = 1
                        },
                        new
                        {
                            ID = 4345,
                            Amount = 79.76m,
                            InvoiceID = 5334,
                            PaymentDate = new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodID = 1
                        },
                        new
                        {
                            ID = 4957,
                            Amount = 114.54m,
                            InvoiceID = 6097,
                            PaymentDate = new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodID = 1
                        },
                        new
                        {
                            ID = 4309,
                            Amount = 145.43m,
                            InvoiceID = 5495,
                            PaymentDate = new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodID = 2
                        },
                        new
                        {
                            ID = 5005,
                            Amount = 176.04m,
                            InvoiceID = 6113,
                            PaymentDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodID = 2
                        },
                        new
                        {
                            ID = 5109,
                            Amount = 191.01m,
                            InvoiceID = 6122,
                            PaymentDate = new DateTime(2020, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethodID = 2
                        });
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.PaymentMethod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Credit Card"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Check"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Cash"
                        });
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Account", b =>
                {
                    b.HasOne("EligoCustomerPortal.Data.Models.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EligoCustomerPortal.Data.Models.Address", null)
                        .WithMany("Accounts")
                        .HasForeignKey("AddressID");

                    b.HasOne("EligoCustomerPortal.Data.Models.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EligoCustomerPortal.Data.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EligoCustomerPortal.Data.Models.Address", "ServiceAddress")
                        .WithMany()
                        .HasForeignKey("ServiceAddressID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Invoice", b =>
                {
                    b.HasOne("EligoCustomerPortal.Data.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EligoCustomerPortal.Data.Models.Payment", b =>
                {
                    b.HasOne("EligoCustomerPortal.Data.Models.Invoice", "Invoice")
                        .WithMany("Payments")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EligoCustomerPortal.Data.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
