using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuailLandingWebsite.Models;

namespace QuailLandingWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configure all entities to be mapped to DB
        /// </summary>
        /// <param name="modelBuilder">The model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuailLandingHome>();
            modelBuilder.Entity<Owner>();
        }

        /// <summary>
        /// Configure all entities to be mapped to DB
        /// </summary>
        /// <param name="modelBuilder">The model builder</param>
        public DbSet<QuailLandingWebsite.Models.QuailLandingHome> Home { get; set; }
    }
}
