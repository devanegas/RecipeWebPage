using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoCore.Models;

namespace TodoCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Recipe>()
                .HasMany(t => t.Ingredients)
                .WithOne(s => s.RecipeParent);

            builder.Entity<Recipe>().HasKey(t => t.Id);
            builder.Entity<Ingredients>().HasKey(s => s.Id);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }

    }
}
