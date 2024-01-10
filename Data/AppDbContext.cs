using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class AppDbContext : DbContext
{

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // Adds the PK and FK and handles the relations in out application
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);

    }
}