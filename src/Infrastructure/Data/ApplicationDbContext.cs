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
        public DbSet<User> Users => Set<User>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Professor> Professors => Set<Professor>();
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<Activity> Activities => Set<Activity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configura la herencia TPH (Table Per Hierarchy) para la entidad User y sus derivados
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<User>("User")
                .HasValue<Client>("Client")
                .HasValue<Professor>("Professor")
                .HasValue<Owner>("Owner");
            // Configuración de la conversión de enums
            modelBuilder.Entity<User>()
                    .Property(d => d.Role)
                    .HasConversion(
                        v => v.ToString(),
                        v => (UserRole)Enum.Parse(typeof(UserRole), v));
            // Configuración de las relaciones entre entidades
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Client)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Activity)
                .WithMany(a => a.Enrollments)
                .HasForeignKey(e => e.ActivityId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada

            // Configuración de la relación entre Activity y Professor
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Professor)
                .WithMany(p => p.Activities)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
