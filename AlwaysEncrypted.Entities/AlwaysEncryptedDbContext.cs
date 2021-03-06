﻿using Microsoft.EntityFrameworkCore;

namespace AlwaysEncrypted.Entities
{
    public class AlwaysEncryptedDbContext : DbContext
    {
        public AlwaysEncryptedDbContext() { }
        public AlwaysEncryptedDbContext(DbContextOptions<AlwaysEncryptedDbContext> options) : base(options) { }

        public DbSet<AdoPatient> AdoPatients { get; set; }
        public DbSet<LinqPatient> LinqPatients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Clinic;Integrated Security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdoPatient>()
                .HasIndex(e => e.FirstName);
            modelBuilder.Entity<AdoPatient>()
                .HasIndex(e => e.LastName);
            modelBuilder.Entity<AdoPatient>()
                .HasIndex(e => e.Ssn);

            modelBuilder.Entity<AdoPatient>()
                .HasIndex(e => e.Ssn)
                .IsUnique();

            modelBuilder.Entity<LinqPatient>()
                .HasIndex(e => e.FirstName);
            modelBuilder.Entity<LinqPatient>()
                .HasIndex(e => e.LastName);
        }
    }
}
