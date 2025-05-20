using Microsoft.EntityFrameworkCore;
using Onlab.Dal.Entities;

namespace Onlab.Dal;
public class AppDbContext : DbContext // IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Band> Bands { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Setlist> Setlists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One-to-Many: Band -> Users

        modelBuilder.Entity<User>()
       .HasOne(u => u.Band)        // User has one Band (or null)
       .WithMany(b => b.Users)   // Band has many Members
       .HasForeignKey(u => u.BandId) // The foreign key is BandId
       .IsRequired(false);

        // One-to-Many: Band -> Concerts

        //modelBuilder.Entity<Concert>()
        //    .HasOne(c => c.Band)
        //    .WithMany(b => b.Concerts)
        //    .HasForeignKey(c => c.BandId);

        // One-to-Many: Band -> Setlists

        //modelBuilder.Entity<Setlist>()
        //    .HasOne(s => s.Band)
        //    .WithMany(b => b.Setlists)
        //    .HasForeignKey(s => s.BandId);

        
    }
}