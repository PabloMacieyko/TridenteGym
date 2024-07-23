using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Professor> Professors => Set<Professor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Profesor");
                entity.HasKey(p => p.Id).HasName("Id");

                entity.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int").ValueGeneratedNever();

                entity.Property(p => p.Name)

                .HasColumnName("name");

            });
        }
    }
}
