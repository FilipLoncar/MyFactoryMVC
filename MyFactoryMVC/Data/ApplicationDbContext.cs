using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFactoryMVC.Models;
using MyFactoryMVC.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFactoryMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MeasureUnit>();

        //    modelBuilder.Entity<Material>().HasOne(x => x.MeasureUnit).HasForeignKey(x => x.ProjectId));

        //    //modelBuilder.Entity<Material>(x => x.HasOne(o => o.MeasureUnit)); //.HasOne(x => x.MeasureUnit);
        //    //modelBuilder.Entity<Product>(x => x.HasMany(m => m.MaterialsNeeded));              
        //}
    }
}
