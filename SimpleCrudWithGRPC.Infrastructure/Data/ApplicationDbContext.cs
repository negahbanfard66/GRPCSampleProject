using Microsoft.EntityFrameworkCore;
using SimpleCrudWithGRPC.Core.Entities;

namespace SimpleCrudWithGRPC.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.NationalCode).IsRequired().HasMaxLength(10);
                entity.Property(p => p.DateOfBirth).IsRequired();
            });
        }
    }
}
