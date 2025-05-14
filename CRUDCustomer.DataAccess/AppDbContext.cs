using CRUDCustomer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // DateTime UTC
        }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerid")
                    .UseIdentityByDefaultColumn().HasIdentityOptions(startValue: 1);

                entity.Property(e => e.CustomerCode)
                     .HasColumnName("customercode")
                     .IsRequired()
                     .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customername")
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerAddress)
                    .HasColumnName("customeraddress")
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasDefaultValue(string.Empty);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdby")
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdat")
                    .IsRequired();

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedby")
                    .IsRequired(false);

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modifiedat")
                    .IsRequired(false);
            });
        }
    }
}
