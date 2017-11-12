﻿
using Notifications.Entities.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifications.Entities.Mappings
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties

            this.Property(t => t.OrderID)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ShipName)
                .HasMaxLength(40);

            this.Property(t => t.ShipAddress)
                .HasMaxLength(60);

            this.Property(t => t.ShipCity)
                .HasMaxLength(15);

            this.Property(t => t.ShipRegion)
                .HasMaxLength(15);

            this.Property(t => t.ShipPostalCode)
                .HasMaxLength(10);

            this.Property(t => t.ShipCountry)
                .HasMaxLength(15);

            this.Property(t => t.Total).HasPrecision(4, 2);

            this.Property(t => t.TotalWithTax).HasPrecision(5, 2);

            

            // Table & Column Mappings
            this.ToTable("Orders");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            //this.Property(t => t.EmployeeID).HasColumnName("EmployeeID").IsOptional();
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.RequiredDate).HasColumnName("RequiredDate").IsOptional();
            this.Property(t => t.ShippedDate).HasColumnName("ShippedDate").IsOptional();
            this.Property(t => t.ShipVia).HasColumnName("ShipVia").IsOptional();
            this.Property(t => t.Freight).HasColumnName("Freight").IsOptional();
            this.Property(t => t.ShipName).HasColumnName("ShipName");
            this.Property(t => t.ShipAddress).HasColumnName("ShipAddress");
            this.Property(t => t.ShipCity).HasColumnName("ShipCity");
            this.Property(t => t.ShipRegion).HasColumnName("ShipRegion");
            this.Property(t => t.ShipPostalCode).HasColumnName("ShipPostalCode");
            this.Property(t => t.ShipCountry).HasColumnName("ShipCountry");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.TotalWithTax).HasColumnName("TotalWithTax");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CustomerID).WillCascadeOnDelete(false);

            this.HasRequired(t => t.Company)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CompanyID).WillCascadeOnDelete(false);

            //this.HasOptional(t => t.Employee)
            //    .WithMany(t => t.Orders)
            //    .HasForeignKey(d => d.EmployeeID);

        }
    }
}
