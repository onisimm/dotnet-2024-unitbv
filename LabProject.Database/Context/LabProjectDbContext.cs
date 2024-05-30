using LabProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Task = LabProject.Database.Entities.Task;

namespace LabProject.Database.Context
{
    public class LabProjectDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<UserProject> UserProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserProject>()
            .HasKey(up => new { up.UserId, up.ProjectId });

        modelBuilder.Entity<UserProject>()
            .HasOne(up => up.User)
            .WithMany(u => u.UserProjects)
            .HasForeignKey(up => up.UserId);

        modelBuilder.Entity<UserProject>()
            .HasOne(up => up.Project)
            .WithMany(p => p.UserProjects)
            .HasForeignKey(up => up.ProjectId);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(50);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=localhost;Database=LabProject;User Id=sa1;Password=Admin123!;TrustServerCertificate=True")
            .LogTo(Console.WriteLine);
    }
}
}
