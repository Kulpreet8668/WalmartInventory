﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalmartInventory.Models;

namespace WalmartInventory.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        //defie our model class so our controller can sccess the model

        public DbSet<Count> Counts { get; set; }
        public DbSet<CountInformation> countInformations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> products { get; set; }

        // override the model creating method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // define relation and keys

            builder.Entity<Product>()
                .HasOne(p => p.Department)
                // every product just have one department
                .WithMany(d => d.Products)
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("FK_Products_DepartmentId");
            // it specify the name of fk for a relationship


            builder.Entity<CountInformation>()
                .HasOne(p => p.Product)
                // every product just have one department
                .WithMany(d => d.CountInformations)
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("FK_CountInformations_ProductId");


            builder.Entity<CountInformation>()
                   .HasOne(p => p.Count)
                   // every product just have one department
                   .WithMany(d => d.CountInformations)
                   .HasForeignKey(p => p.CountId)
                   .HasConstraintName("FK_CountInformations_CountId");
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
