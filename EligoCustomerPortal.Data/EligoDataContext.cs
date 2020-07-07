using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Configuration;

namespace EligoCustomerPortal.Data
{
    public class EligoDataContext : DbContext
    {
        public EligoDataContext(DbContextOptions<EligoDataContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DBConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e => 
            {
                e.HasOne(e => e.BillingAddress)
                .WithMany()
                .HasForeignKey(e => e.BillingAddressID)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.ServiceAddress)
                .WithMany()
                .HasForeignKey(e => e.ServiceAddressID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //Populates the DB with sample data for the web app.
            modelBuilder.AddInitialSeedData();
        }
    }
}
