using MeraStore.Service.Logging.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MeraStore.Service.Logging.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<Request> Requests { get; set; }
  public DbSet<Response> Responses { get; set; }
 

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    // Configuring Request
    modelBuilder.Entity<Request>(entity =>
    {
      entity.ToTable("Requests"); // Set the table name

      entity.HasKey(e => e.Id); // Set Id as the primary key
      entity.Property(e => e.Endpoint)
        .IsRequired()
        .HasMaxLength(500); // Set max length for Endpoint
      entity.Property(e => e.Content)
        .IsRequired(); // Mark as required
      entity.Property(e => e.Timestamp)
        .IsRequired(); // Mark as required
    });

    // Configuring Response
    modelBuilder.Entity<Response>(entity =>
    {
      entity.ToTable("Responses"); // Set the table name

      entity.HasKey(e => e.Id); // Set Id as the primary key
      entity.Property(e => e.Endpoint)
        .IsRequired()
        .HasMaxLength(500); // Set max length for Endpoint
      entity.Property(e => e.Content)
        .IsRequired(); // Mark as required
      entity.Property(e => e.Timestamp)
        .IsRequired(); // Mark as required
    });
  }
}