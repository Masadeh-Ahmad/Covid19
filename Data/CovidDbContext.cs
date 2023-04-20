using Covid.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Covid.Data
{
    public class CovidDbContext : DbContext
    {
        public DbSet<Records> records { get; set; }

        public CovidDbContext(DbContextOptions<CovidDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Records>()
                        .HasIndex(p => p.CountryId)
                        .IsUnique();
        }


    }
}